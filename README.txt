-------------------------------------------------------------------------------------------------------------------
                                    BITTE Lesen Sie die README vollstaendig und sorgfaeltig!
-------------------------------------------------------------------------------------------------------------------


-------------------------------------------------------------------------------------------------------------------
                                                        Aufgabenteil a)
-------------------------------------------------------------------------------------------------------------------
Fortbewegungsaufgabe:
    - Sie erhalten nach einem harten Arbeitstag eine Liste mit vier verschiedenen Artikeln, die Sie noch einkaufen muessen. Dummerweise gibt es nur ein einziges Kaufhaus, die sie momentan auf Lager hat. Für dieses Kaufhaus steht morgen ein Umbau bevor, weshalb nur noch ein Exemplar von diesen Artikeln zur Verfuegung steht.
    - Ihr Ziel ist es, alle benoetigten Artikel einzusammeln.
    - Die vier Artikel werden bei jedem Start randomisiert ausgewaehlt.
    - Es wird dabei zugesichert, dass sie in beiden Etagen genau zwei Artikel sammeln müssen. Hiermit muessen Sie einmal mit der Rolltreppe fahren.

Verwendete Locomotion:
    - Metapher: 
        - Steering-Leaning
            - 1 DOF vTranslation: Durch Lehnen wie ein "human joystick" entlang der z-Achse.
            - 1 DOF vRotation: Durch Bewegen der Controller bzw. der physischen Stange entlang der x-Achse.
    - Travel Task:
        - Search
    - Funktion:
        - Leaning:
            - Funktion: Powerfunktion mit Deadzone von 5 cm
            - Maximalgeschwindigkeit: 5 Meter pro Sekunde nach 34.8 cm
        - Steering:
            - Funktion: Powerfunktion mit Deadzone von 10 cm
            - Maximalgeschwindigkeit: 30 Grad pro Sekunde nach 28.3 cm

Testen der Aufgabe und der Locomotion im Stehen durch Michael Feldmann und Jan Niclas Ruppenthal:
    - Beide sollten die Aufgabe dreimal durchfuehren. Dabei haben beide nach dem zweiten Durchlauf abgebrochen, da wir bemerkt haben, dass unsere Rotation Cybersickness verursacht. Um dies ein wenig zu lindern, haben wir nun die Rotationsgeschwindigkeit von 45 Grad pro Sekunde auf 30 Grad pro Sekunde heruntergesenkt. Zudem kann man die Locomotion auch sitzend verwenden um Cybersickness vorzubeugen, aber ein Segway betreibt man normalerweise im Stehen.
    - Die Translation ueber Lehnen konnten von beiden gut bedient werden. 
    - Die Aufgabe kann sehr schnell geloest werden.
    - Die Locomotion wird auf der Rolltreppe deaktiviert. Dies fanden beide gut, da dies als eine kurze Ruhepause dienen konnte. Des Weiteren vibrieren auch die Controller waehrend der Fahrt auf der Rolltreppe. Wenn die Vibration nachlaesst, ist das ein Indikator fuer den Nutzer, dass die Locomotion wieder eingeschaltet ist.
    - Bis auf die Rolltreppe erzielen wir eine hohe Nutzerfreiheit.


-------------------------------------------------------------------------------------------------------------------
                                                        Aufgabenteil b)
-------------------------------------------------------------------------------------------------------------------
Wieso wurde dieses Interface implementiert?
    - Wir haben eine uns bekannte Fortbewegungsmethode gesucht, die mit Kopf- und Handbewegungen gleichzeitig gesteuert werden kann. Dabei wollten wir auch etwas Bekanntes fuer die Immersion verwenden. Dabei ist das Interface durch die Inspiration eines Segways einfacher zu erlernen.

Staerken des Interfaces:
    - Wir haben eine multimodale Interaktion implementiert.
        - Vibration der Controller werden je nach Geschwindigkeit des Segways staerker oder schwaecher.
        - Durch die physische Stange kann die Vibration der Controller verstaerkt werden.
    - Da wir uns fuer ein plausibles Szenario entschieden haben, erzielen wir eventuell eine hoehere Immersion.
    - Durch die Verwendung einer Powerfunktion sowohl fuer die Translation als auch fuer die Rotation wird eine hoehere Praezision der Fortbewegung erzielt.
    - Dabei haben wir uns auch fuer eine Deadzone entschieden, damit man sich nicht bei jeder kleinen Bewegung des Kopfes oder der Controller/physischen Stange virtuell bewegt.

Schwaechen des Interfaces:
    - Eine physische Rotation des gesamten Körpers macht das Interface kaputt.
    - Auch wenn wir die Rotationsgeschwindigkeit verringert haben, verursacht sie trotzdem noch Cybersickness.
    - Eine virtuelle vertikale Bewegung ist nur begrenzt moeglich. Man kann sich nur vertikal ueber die Rolltreppe bewegen. Die ist jedoch statisch, da die Locomotion ausgeschaltet wird.
    - Unsere Methode ist nicht gut auf Groessen skalierbar. Wir koennen fuer grosse Distanzen nicht die Maximalgeschwindigkeit erhoehen, da der Nutzer sonst weniger Kontrolle ueber das Segway verfuegt und die Cybersickness kann dadurch auch erhoeht werden.
    - Durch die virtuelle mittlere Stange des Segways wird hier ein Verlust der Immersion erzielt. 
    - Die Controller muessen von der Quest 3 getrackt werden. Falls das Tracking fehlschlaegt, dann kann das Interface nicht genutzt werden.

Messung der Performance:
    - Wir koennen fuer jeden Probanden die Zeit messen.
    - Wir loggen die Anzahl der Kollisionen mit Waenden oder anderen Objekten. Falls der Nutzer eine hohe Anzahl an Kollisionen erzielt, dann konnte dieser seine Umgebung nicht gut wahrnehmen.

Messung der Nutzbarkeit:
    - Durchfuehrung einer empirischen Studie zur Usability:
        - Einkaufsaufgabe durchfuehren und die Probanden muessen sich merken, wo sie die passenden Artikel gefunden haben.
        - Dabei kann man die Nutzbarkeit nach der Aufgabe mit standardisierten Frageboegen, wie bspw. der System Usability Scale (SUS) oder der NASA-TLX bewerten.
        - Zudem kann man diese Studie mithilfe eines Vergleichs erweitern: Man kann unsere Methode mit anderen Interfaces wie z.B. pointing-based Steering oder redirected walking vergleichen.



-------------------------------------------------------------------------------------------------------------------
                                                        Starten des Projekts
-------------------------------------------------------------------------------------------------------------------
Wenn Sie unser Unity Projekt geoeffnet haben, dann muessen Sie eventuell Unity mehrmals neustarten.

Beim ersten Start des Editors kommt eine Meldung, dass Veraenderungen im OVRPlugin erkannt wurden. Hierzu muessen Sie nur den Editor neustarten.


Wenn der Editor neugestartet wurde, dann entstehen drei neue Fehlermeldungen:
    - "[Package Manager Window] Error while getting auth code: User is not logged in or user status invalid. Unity.Editor.EditorApplication:Internal_CallUpdateFunctions ()" 
    - "[Package Manager Window] Error while getting auth code: User is not logged in or user status invalid. Unity.Editor.EditorApplication:Internal_CallUpdateFunctions ()" 
    - "[Package Manager Window] Error while getting auth code: User is not logged in or user status invalid. Unity.Editor.EditorApplication:Internal_CallUpdateFunctions ()" 


Hierzu koennen Sie einfach Unity erneut neustarten, dann sind die drei Fehlermeldungen auch verschwunden.

Wir haben auch alternative Loesungsvorschlaege:
    - https://forum.unity.com/threads/package-manager-window-unable-to-perform-online-search.1136377/


Dabei koennen Sie auch alle Meldungen aus der Konsole des Unity Editors loeschen. Die Meldungen haben keine Auswirkungen auf unsere Applikation!


-------------------------------------------------------------------------------------------------------------------
                                                            Gameplay
-------------------------------------------------------------------------------------------------------------------
Das Gameplay wurde durch die Funktionalitäten eines Segway inspiriert.

Translation:
    - Vorn: Lehnen nach Vorn
    - Hinten: Lehnen nach Hinten

Rotation:
    - Rechts: Controller (evtl. mit physischer Stange) entlang der positiven x-Achse bewegen
    - Links: Controller (evtl. mit physischer Stange) entlang der negativen x-Achse bewegen


Einsammeln der Artikel:
    - Mit den Haenden kann man mit den Artikeln interagieren


Controller:
    - Hupen: Den PrimaryHandTrigger oder SecondaryHandTrigger druecken
    - Liste de- oder aktivieren: Den PrimaryIndexTrigger oder SecondaryIndexTrigger druecken


-------------------------------------------------------------------------------------------------------------------
                                                            Assets
-------------------------------------------------------------------------------------------------------------------
SDK:
    - Meta XR Core SDK: https://assetstore.unity.com/packages/tools/integration/meta-xr-core-sdk-269169
    - Meta Interaction OVR Integration SDK (Wir haben hier das OVRCameraRigInteraction verwendet, aber alle bereits implementierten Interaktionen gelöscht! Dabei wird auch das Meta XR Interaction SDK installiert): https://assetstore.unity.com/packages/tools/integration/meta-xr-interaction-sdk-ovr-integration-265014
    - Oculus XR Plugin

Text:
    - TextMesh Pro

Musik und Sound:
    - Hintergrundmusik: https://www.101soundboards.com/sounds/24303004-wii-shop
    - Hupe: https://www.101soundboards.com/sounds/27481824-horn-honk-short


Kaufhaus:
    - Uhr: https://assetstore.unity.com/packages/3d/props/interior/clock-free-44164
    - Brunnen: https://sketchfab.com/3d-models/fountain-1e2234e51a46400bbd3a71afd9c2b750#download
    - Bank: https://assetstore.unity.com/packages/3d/environments/modern-bench-pack-221011
    - Rahmen fuer die Poster: https://sketchfab.com/3d-models/poster-frame-fb500d75d785433c8b82fdafac9e18cb
    - Pothos Pflanzen: https://sketchfab.com/3d-models/free-pothos-potted-plant-money-plant-e9832f38484f4f85b3f9081b51fa3799
    - WC Tueren: https://assetstore.unity.com/packages/3d/props/interior/door-free-pack-aferar-148411
    - Laeden: https://sketchfab.com/3d-models/sketchfab-store-in-mall-957c1d65e6db4598a198f7ac3888fed1

Bilder fuer die Poster:
    - Deutsche Nationalmannschaft: https://www.ferrero-sammelspass.de/img/shop/Album/998-album.jpg?version=9
    - Der Kaufhaus Cop: https://image.tmdb.org/t/p/original/5o8kxVsJKw9bdxtsIreBNHSClID.jpg
    - konzenTRiert: https://www.uni-trier.de/fileadmin/_processed_/1/5/csm_Titelseite_konzenTRiert2021_b65cd70fe6.jpg
    - Trier: https://www.lieferlokal.de/sites/default/files/styles/1700x2424/public/tr-produktmood-00.jpg?itok=w6Smw1I6
    - Angry Birds von der zweiten Uebung haben wir selbst erstellt.
    - Ames Room von der ersten Uebung haben wir selbst erstellt.
    - Tabletten: https://www.adworld.ie/wp-content/uploads/2016/09/op.jpg
    - Seven-Up: https://grist.org/wp-content/uploads/2010/07/ad_7up175baby.jpg
    - Mario: https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/64f85628578453.55c7bc0a8498b.jpg
