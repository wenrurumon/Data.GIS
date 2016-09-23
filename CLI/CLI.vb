﻿Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.GIS
Imports Microsoft.VisualBasic.Imaging.SVG

Module CLI

    <ExportAPI("/Rendering",
               Usage:="/Rendering /in <data.csv> [/map <map.svg> /iso_3166 <iso_3166.csv> /out <out.svg>]")>
    Public Function Rendering(args As CommandLine) As Integer
        Dim [in] As String = args("/in")
        Dim map As String = args("/map")
        Dim iso_3166 As String = args("/iso_3166")
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & ".rendering.svg")
        Dim data As IEnumerable(Of Data) = [in].LoadCsv(Of Data)
        Dim svg As SVGXml = data.Rendering
        Return svg.SaveAsXml(out).CLICode
    End Function
End Module