# Demonstration einer Console Application mit SharePoint App Only Credentials

## Vorbereitung

Registrieren eines neuen SharePoint Add-Ins analog zu
https://docs.microsoft.com/en-us/sharepoint/dev/sp-add-ins/register-sharepoint-add-ins

### 1) Unter <~site>/_layouts/15/AppRegNew.aspx ein neues Addin registrieren

| Feld        | Wert           | Beschreibung  |
| ------------- |:-------------:| -----:|
| Client-ID     | generieren lassen |  |
| Clientschlüssel| generieren lassen | Wichtig: hier merken, kann nicht wieder eingesehen werden |
| Titel     | beliebig |  |
| App-Domäne     | localhost |  |
| Weiterleitungsurl    | http://localhost |  |

### 2) Unter <~site>/_layouts/15/AppInv.aspx das Addin berechtigen

| Feld        | Wert           | Beschreibung  |
| ------------- |:-------------:| -----:|
| 	App-ID     | eintragen/nachschlagen |  |
| Titel     | nachschlagen |  |
| App-Domäne     | nachschlagen |  |
| Weiterleitungsurl    | nachschlagen |  |

Dann im Feld "Berechtigungsanforderungs-XML" das folgende einfügen

```
<AppPermissionRequests AllowAppOnlyPolicy = "true">
    <AppPermissionRequest Scope = "http://sharepoint/content/sitecollection" Right = "FullControl" />
</AppPermissionRequests>
```

um dem Addin die volle Kontrolle über die SiteCollection und das Einloggen ohne Benutzernamen (apponlypolicy) zu erlauben.

### 3) In der app.config Datei die korrekten Werte für das Addin setzen

```
  <appSettings>
    <add key="SiteUrl" value="XXXXXXXXXXXXXXXXXXXXXX" />
    <add key="AppID" value="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" />
    <add key="AppSecret" value="XXXXXXXXXXXXXXXXXXXXXXXXXX" />
  </appSettings>
```