Serious Game: Save The Ocean

Fuer unser Spiel haben wir uns fuer die folgenden Themen entschieden:
    - Nachhaltigkeit
    - Foerderung von Empathie
    - Bildung und Aufklaerung


--------------------------------------------------------------------------------------------------------------------------------------

Adressierte Kriterien

Technischer Aufwand und Qualitaet der technischen Umsetzung:
    - Simulation von ueber 3000 Korallen
    - Unendliche Generierung der Landschaft
    - Simulation eines einfachen Schwarms

Authentizitaet und Immersion der vermittelten Inhalte:
    - Verschlechterung der Sicht durch Einsatz eines Nebels und einer allmaehlichen Grauwerdung mit Post-Processing
    - Leben und Sterben der Meereslebewesen (Fische, Korallen und Schildkroeten), wenn zu wenig Muell aufgesammelt wird
    - Simulation des Atems durch eine Sinuskurve oder durch Eingabe des Mikrofons. Der Atem wird durch ein Partikelsystem visualisiert.
    - Bewegung ist nur mithilfe des Diver Propulsion Vehicles (DPVs) moeglich, hierbei dreht sich zusaetzlich der Rotor des DPVs
    - Faktenvideo in einem Raum am Ende der Simulation, welches über die Problematik des Meeresmuells und dessen weitreichende Auswirkungen aufklaert

Nutzbarkeit (Usability) und Benutzererfahrung (User Experience):
    - Radar, um den Muell zu orten
    - Rote Outline an den Muellobjekten, damit man diese in der Naehe von Korallen besser erkennen kann
    - Bewegung: Steering durch Pointing-based implementiert mit 3 DOF vTranslation und physischer Rotation durch eine lineare Funktion mit Maximalgeschwindigkeit von 5 m/s
    - Neustart mithilfe eines User Interfaces (UI) am Ende des Spiels

Einsatz von 3D Interaktionen und multimodalem Feedback:
    - Greifen des Muells mithilfe eines Controllers
    - Vibration der Controller in Abhaengigkeit der aktuellen Geschwindigkeit


--------------------------------------------------------------------------------------------------------------------------------------

Tastenbelegungen:
    - Greifen: Den Abfall und der Griff des DPV kann man mithilfe der Greiftaste greifen.
    - Fortbewegung: Wenn man mit mindestens einem Controller das DPV greift, kann man mithilfe des rechten Triggers die Geschwindigkeit des DPVs einstellen.
    - Drehen: Falls ein sicheres physisches Drehen nicht gewaehrleistet ist, kann der Stick am rechten Controller für eine horizontale Drehung genutzt werden.
    - UI-Interaktion: Durch das Druecken eines Buttons des UIs mit dem Controller.


--------------------------------------------------------------------------------------------------------------------------------------

Verwendete externe Ressourcen:

Virtual Reality und 3D Interaktionen:
    - XR Interaction Toolkit


Sound waehrend des Spiels:
    - Ambiente: https://freesound.org/people/Xemptful/sounds/406623/
    - Luftblasen : https://freesound.org/people/ristooooo1/sounds/539819/?page=2#comments

Spielszene:
    - Lebewesen
        - Schildkroete: https://sketchfab.com/3d-models/sea-turtle-23dcb315dea44f5082b020b04710bd31
        - Fisch: https://assetstore.unity.com/packages/3d/characters/animals/fish/emperor-angelfish-263329
        - Korallen 01: https://sketchfab.com/3d-models/koraller-snm21005-d385ddbdef4340a2b0ee48eab81b785f
        - Korallen 02: https://sketchfab.com/3d-models/lowpoly-coral-pack-29d5be0e220f48818346cabfa065e887

    - Muell:
        - Muellsack: https://sketchfab.com/3d-models/low-poly-trash-bag-69876d51e2f0462498b81dffe3387ae0#download
        - Dosen: https://sketchfab.com/3d-models/tin-cans-ff0665ece31d4c4eb6182a4756c583bf
        - Kefir: https://sketchfab.com/3d-models/kefir-bottle-fe82b4f4286a48f294ebf05f8d264691
        - Joghurt: https://sketchfab.com/3d-models/yogurt-7cf010b5a4d245c8ae07be585aadc2b8#download
        - Flasche: https://sketchfab.com/3d-models/bottle-f06024f0949b4f78afd60b879fee9de9
        - Zerbeulte Dose: https://assetstore.unity.com/packages/tools/modeling/mess-maker-free-213803

Game Over Raum (Video und Sound):
    - Bilder:
        - https://pixahive.com/photo/__trashed-32113/
        - https://pixahive.com/photo/plastic-bottle-and-plastic-bags-on-ocean-floor/
        - https://pixahive.com/photo/a-polluted-river-8/
        - https://pxhere.com/en/photo/1365482
        - https://pxhere.com/en/photo/558663
        - https://pxhere.com/en/photo/1611355
        - https://pxhere.com/en/photo/428305
        - https://pxhere.com/en/photo/1414425

    - Fakten:
        - https://en.nabu.de/topics/ecosystems/ocean-trash.html
        - https://www.unep.org/plastic-pollution
        - https://www.europarl.europa.eu/pdfs/news/expert/2018/10/story/20181005STO15110/20181005STO15110_en.pdf
        - https://www.science.org/doi/10.1126/science.aar3320

    - Sound: https://freesound.org/people/guitarman213/sounds/707899/

Sonstige Ressourcen:
    - Quick Outline: https://assetstore.unity.com/packages/tools/particles-effects/quick-outline-115488
    - Mass Spawner: https://assetstore.unity.com/packages/tools/terrain/mass-spawner-object-placement-tool-191111
    - Zweiseitige Shader: https://assetstore.unity.com/packages/vfx/shaders/free-double-sided-shaders-23087
    - Post Processing
    - TextMeshPro
