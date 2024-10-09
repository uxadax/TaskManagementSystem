## 🕒 Time API Dokumentation
 
### 1. Übersicht
Die Time API des Task Management Systems ermöglicht es, die aktuelle Zeit von verschiedenen Zeitzonen abzurufen. Die API basiert auf der Verwendung von `http://worldtimeapi.org`, um die aktuelle Zeit einer spezifischen Zeitzone abzurufen. Die API liefert die Uhrzeit im Format `YYYY-MM-DDTHH:MM:SS` und aktualisiert sich in regelmäßigen Intervallen.
 
### 2. Basis-URL
```
http://worldtimeapi.org/api/timezone/
```
 
### 3. Endpunkte
 
| Methode | Endpoint                             | Beschreibung                            |
|---------|--------------------------------------|-----------------------------------------|
| `GET`   | `/timezone/Europe/Zurich`             | Abruf der aktuellen Zeit für Zürich, Schweiz |
| `GET`   | `/timezone/Europe/Berlin`             | Abruf der aktuellen Zeit für Berlin, Deutschland |
| `GET`   | `/timezone/America/New_York`          | Abruf der aktuellen Zeit für New York, USA |
| `GET`   | `/timezone/Asia/Tokyo`                | Abruf der aktuellen Zeit für Tokyo, Japan |
 
### 4. Beispielanfrage
#### `GET /timezone/Europe/Zurich`
- **Beschreibung:** Diese Anfrage liefert die aktuelle Zeit in Zürich, Schweiz.
- **Anfrage:**
 
```http
GET http://worldtimeapi.org/api/timezone/Europe/Zurich
```
 
- **Antwort:**
```json
{
  "abbreviation": "CEST",
  "client_ip": "xxx.xxx.xxx.xxx",
  "datetime": "2024-10-09T07:07:24.123456+02:00",
  "day_of_week": 3,
  "day_of_year": 282,
  "dst": true,
  "dst_from": "2024-03-31T02:00:00+00:00",
  "dst_offset": 3600,
  "dst_until": "2024-10-27T02:00:00+00:00",
  "raw_offset": 3600,
  "timezone": "Europe/Zurich",
  "unixtime": 1633787044,
  "utc_datetime": "2024-10-09T05:07:24.123456+00:00",
  "utc_offset": "+02:00",
  "week_number": 41
}
```
 
### 5. Antwortparameter
 
| Parameter        | Typ      | Beschreibung                                                  |
|------------------|----------|--------------------------------------------------------------|
| `abbreviation`   | `string` | Zeitzonenabkürzung (`CEST` für Central European Summer Time)   |
| `client_ip`      | `string` | IP-Adresse des Clients                                       |
| `datetime`       | `string` | Datum und Uhrzeit im Format `YYYY-MM-DDTHH:MM:SS`             |
| `day_of_week`    | `int`    | Wochentag (1 = Montag, 7 = Sonntag)                           |
| `day_of_year`    | `int`    | Tag des Jahres (z.B. 282 für den 282. Tag)                    |
| `dst`            | `bool`   | Gibt an, ob Sommerzeit aktiv ist                              |
| `dst_from`       | `string` | Startdatum der Sommerzeit                                     |
| `dst_offset`     | `int`    | Offset der Sommerzeit in Sekunden                             |
| `dst_until`      | `string` | Enddatum der Sommerzeit                                       |
| `raw_offset`     | `int`    | Rohzeit-Offset der Zeitzone in Sekunden                       |
| `timezone`       | `string` | Zeitzonenname (`Europe/Zurich`)                               |
| `unixtime`       | `int`    | Unix-Zeitstempel                                             |
| `utc_datetime`   | `string` | Datum und Uhrzeit in UTC                                      |
| `utc_offset`     | `string` | Offset zu UTC (`+02:00` für Mitteleuropa während Sommerzeit)  |
| `week_number`    | `int`    | Kalenderwoche des Jahres                                      |
 
### 6. Fehlerbehandlung
 
Die API verwendet die folgenden HTTP-Statuscodes, um den Erfolg oder Fehler einer Anfrage zu kennzeichnen:
 
| Status Code | Bedeutung                                     |
|-------------|----------------------------------------------|
| `200 OK`    | Die Anfrage wurde erfolgreich bearbeitet.     |
| `400 Bad Request` | Die Anfrage enthält fehlerhafte Daten.  |
| `404 Not Found` | Die angeforderte Ressource wurde nicht gefunden. |
| `500 Internal Server Error` | Ein unerwarteter Serverfehler ist aufgetreten. |
 
### 7. Beispiel für `curl`-Befehle
 
1. **Aktuelle Zeit für Zürich abrufen:**
   ```bash
   curl -X GET http://worldtimeapi.org/api/timezone/Europe/Zurich
   ```
 
2. **Aktuelle Zeit für Berlin abrufen:**
   ```bash
   curl -X GET http://worldtimeapi.org/api/timezone/Europe/Berlin
   ```
 
3. **Aktuelle Zeit für New York abrufen:**
   ```bash
   curl -X GET http://worldtimeapi.org/api/timezone/America/New_York
   ```
 
### 8. Hinweise
- Die API-Antworten sind immer im `application/json`-Format.
- Die `datetime`-Antwort zeigt die aktuelle Zeit inklusive Millisekunden.
- Der `dst`-Parameter gibt an, ob derzeit Sommerzeit aktiv ist.
 
### 9. Tipps zur Implementierung in deiner Anwendung
 
1. **Automatische Aktualisierung der Uhrzeit:**  
   Implementiere einen Timer in deiner Anwendung, um die Uhrzeit regelmäßig abzufragen und in einem Label anzuzeigen, wie es bereits in deinem bestehenden Code verwendet wird.
 
2. **Fehlerbehandlung:**  
   Stelle sicher, dass du die Fehlerbehandlung für Netzwerkprobleme oder ungültige Zeitzonen berücksichtigst, indem du die HTTP-Statuscodes auswertest.
 
3. **Benutzerdefinierte Zeitzonen:**  
   Erweitere die Anwendung, um es Benutzern zu ermöglichen, verschiedene Zeitzonen auszuwählen und die aktuelle Zeit für diese anzuzeigen.
 
