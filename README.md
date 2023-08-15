## Disable-Windows-Defender
## Program disable Windows Defender all verison WIndows 10. WIndows 10 Version 1607 - Windows Version 22H2


Tamper protection has appeared by windows 10 Version 1903. 

You can disabled windows defender from Windows Register until windows 10 1903 version.

Started with 1903 version you should disable tamper protection and later windows defender

## ! Before work with register and powershell

You should add manifest file and change node that you  are become admin

```ruby
 <requestedExecutionLevel level="requireAdministrator" uiAccess="false" />
```

## Work with Windows Register:

You should add these node in Windows Register and create method work with Register

```ruby
regedit.RegistryKeyChange(@"SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", "1");
regedit.RegistryKeyChange(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableBehaviorMonitoring", "1");
regedit.RegistryKeyChange(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableOnAccessProtection", "1");
regedit.RegistryKeyChange(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableScanOnRealtimeEnable", "1");
```

## Powershell

You should disable tamper protection and next you should run these command and create method which work with cmd

```ruby
powershell.SendPowershellCmd("Set-MpPreference -DisableIntrusionPreventionSystem $true -DisableIOAVProtection $true -DisableRealtimeMonitoring $true");
powershell.SendPowershellCmd("Set-MpPreference -DisableScriptScanning $true");
powershell.SendPowershellCmd("Set-MpPreference -EnableControlledFolderAccess Disabled");
powershell.SendPowershellCmd("Set-MpPreference -EnableNetworkProtection AuditMode -Force -MAPSReporting Disabled -SubmitSamplesConsent NeverSend");
```

You can download my project if you don't want create methods
