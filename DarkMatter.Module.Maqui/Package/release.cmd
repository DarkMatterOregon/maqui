del "*.nupkg"
"..\..\oqtane.framework\oqtane.package\nuget.exe" pack DarkMatter.Module.Maqui.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\Packages\" /Y

