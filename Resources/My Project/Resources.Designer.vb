﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Microsoft.VisualBasic.Data.GIS.Resources.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property BlankMap_World6() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("BlankMap_World6", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to name,alpha2,alpha3,code
        '''Aruba,AW,ABW,533
        '''Afghanistan,AF,AFG,4
        '''Angola,AO,AGO,24
        '''Anguilla,AI,AIA,660
        '''&quot;Åland Islands&quot;,AX,ALA,248
        '''Albania,AL,ALB,8
        '''Andorra,AD,AND,20
        '''&quot;United Arab Emirates&quot;,AE,ARE,784
        '''Argentina,AR,ARG,32
        '''Armenia,AM,ARM,51
        '''&quot;American Samoa&quot;,AS,ASM,16
        '''Antarctica,AQ,ATA,10
        '''&quot;French Southern Territories&quot;,TF,ATF,260
        '''&quot;Antigua and Barbuda&quot;,AG,ATG,28
        '''Australia,AU,AUS,36
        '''Austria,AT,AUT,40
        '''Azerbaijan,AZ,AZE,31
        '''Burundi,BI,BDI,108
        '''Belgium,BE,BEL,56
        '''Benin,BJ,BEN,204
        '''&quot;Bonaire, Sint Eustatius [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property ISO_3166_1() As String
            Get
                Return ResourceManager.GetString("ISO_3166_1", resourceCulture)
            End Get
        End Property
    End Module
End Namespace