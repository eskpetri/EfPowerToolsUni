# EfPowerToolsUni

This was just to test EF Core Power Tools extension to Visual Studio 2022.
https://github.com/ErikEJ/EFCorePowerTools

Major point to note is DateOnly and TimeOnly EF and JSON conversion implementation. (Student.cs and Grade.cs)

I found bunch of work arounds how to avoid DateOnly and TimeOnly fields. Most common was naming it to DateTime. Next was making conversion to every property that uses DateOnly or TimeOnly fields so you need to keep that in mind when maintenancing application or adding fields. 

Anyway Jasper Kent solution to overwrite EF and JSON Converters in same named subdirectory handles the root problem solution wide. 
https://github.com/JasperKent/DateTimeAPI
