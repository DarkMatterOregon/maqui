del "*.nupkg"
"..\..\oqtane.framework\oqtane.package\nuget.exe" pack DarkMatter.Theme.Maqui.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Themes\" /Y
