
begin
{
	$schema_folders = gci $env:ProgramFiles -Filter "Microsoft Visual Studio*" | 
						gci -Filter "Xml" | 
						gci -Filter "Schemas"
}

process
{
	if(!$_ -or !(Test-Path $_))
	{
		Write-Error "File '$_' not found"
		break;
	}
	if((gi $_).Extension -ine ".xsd")
	{
		Write-Warning "File $_ does not end in an .xsd extension"
	}

	foreach($folder in $schema_folders){
		#It is very interesting I had to use .FullName...
		"cp '$_' '$($folder.FullName)'"
		cp $_ $folder.FullName
	}
}
