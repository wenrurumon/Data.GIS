﻿Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.SVG
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Mathematical
Imports Microsoft.VisualBasic.SoftwareToolkits

Public Module ColorRender

    ReadOnly __iso_3166 As ISO_3166()
    ''' <summary>
    ''' <see cref="SVGXml"/>
    ''' </summary>
    ReadOnly BlankMap_World6 As String
    ReadOnly statDict As Dictionary(Of String, String)

    Sub New()
        Dim res As New Resources(GetType(ColorRender))
        Dim ISO_3166_1 As String = res.GetString(NameOf(ISO_3166_1))

        __iso_3166 = ImportsData(Of ISO_3166)(ISO_3166_1,)
        BlankMap_World6 = res.GetString(NameOf(BlankMap_World6))

        statDict = (From x As ISO_3166
                    In __iso_3166
                    Select {
                        x.name.ToLower,
                        x.alpha2,
                        x.alpha3,
                        x.code}.Select(Function(code) New With {
                            .code = code,
                            .alpha2 = x.alpha2
                        })).MatrixAsIterator.ToDictionary(
                            Function(x) x.code,
                            Function(x) x.alpha2)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="mapLevels"></param>
    ''' <param name="mapTemplate">Using this parameter for custom map template.(自定义的地图模板)</param>
    ''' <returns></returns>
    <Extension>
    Public Function Rendering(data As IEnumerable(Of Data),
                              Optional mapLevels As Integer = 256,
                              Optional mapTemplate As String = Nothing,
                              Optional mapName As String = Nothing,
                              Optional ByRef legend As Bitmap = Nothing) As SVGXml

        Dim empty As SVGXml = SVGXml.TryLoad(
            If(String.IsNullOrEmpty(mapTemplate),
            BlankMap_World6,
            mapTemplate))
        Dim designer As New ColorDesigner(data, mapName, mapLevels)

        For Each state As Data In designer.data
            Dim c As node = empty.__country(state.state)

            If c Is Nothing Then
                Continue For
            End If

            Dim mapsColor As Color = designer.GetColor(state.value)
            Dim color As Color = If(
                String.IsNullOrEmpty(state.color),
                mapsColor,
                state.color.ToColor(
                onFailure:=mapsColor))
            Call c.FillColor(color.RGBExpression)
        Next

        legend = designer.DrawLegend("Title")

        Return empty
    End Function

    <Extension> Public Sub FillColor(ByRef g As node, color As String)
        g.style = $"fill: {color};"  ' path/g

        If TypeOf g Is g Then
            Dim x As g = DirectCast(g, g)

            For Each [sub] As g In x.gs.SafeQuery
                Call [sub].FillColor(color)
            Next

            For Each path As path In x.path.SafeQuery
                path.style = g.style
            Next
        End If
    End Sub

    ''' <summary>
    ''' thanks to the XML/HTML style of the SVG (and Nathan’s explanation) I can create CSS classes per country 
    ''' (the polygons of each country uses the alpha-2 country code as a class id)
    ''' </summary>
    ''' <param name="map"></param>
    ''' <param name="code"></param>
    ''' <returns></returns>
    <Extension>
    Private Function __country(map As SVGXml, code As String) As node
        Dim alpha2 As String =
            If(statDict.ContainsKey(code),
            statDict(code),
            statDict.TryGetValue(code.ToLower))
        Dim c As node = map.gs.__country(alpha2)

        If c Is Nothing Then
            c = map.path.__country(alpha2)

            If c Is Nothing Then
                Call $"Unable found Object named '{code}'!".PrintException
            End If
        End If

        Return c
    End Function

    <Extension>
    Private Function __country(subs As path(), alpha2 As String) As path
        For Each path As path In subs
            If path.id.TextEquals(alpha2) Then
                Return path
            End If
        Next

        Return Nothing
    End Function

    <Extension>
    Private Function __country(subs As g(), alpha2 As String) As g
        Dim state As New Value(Of g)

        For Each c As g In subs
            If alpha2.TextEquals(c.id) Then
                Return c
            Else
                If c.gs.IsNullOrEmpty Then
                    Continue For
                End If
            End If

            If Not (state = c.gs.__country(alpha2)) Is Nothing Then
                Return state
            End If
        Next

        Return Nothing
    End Function
End Module
