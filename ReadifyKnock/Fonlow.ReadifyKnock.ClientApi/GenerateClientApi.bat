cd %~dp0
:: generate wsdl. Run this when there's a breaking change in the interface. You still need to be careful about interface versioning.
"C:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools\svcutil.exe" https://knockknock.readify.net/RedPill.svc?singleWsdl /syncOnly /n:http://KnockKnock.readify.net,Fonlow.ReadifyKnock /o:ReadifyKnockKnockAuto.cs 
pause