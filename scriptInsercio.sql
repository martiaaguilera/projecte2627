-- DESACTIVEM LES FK PERQUE TRUNCATE POT FALLAR SI HI HA CLAUS FORANES

ALTER TABLE PARADA DISABLE CONSTRAINT FK_PARADA_TRAJECTE;
ALTER TABLE PARADA DISABLE CONSTRAINT FK_PARADA_ESTACIO;
ALTER TABLE TRAJECTE DISABLE CONSTRAINT FK_TRAJECTE_MITJATRANSPORT;
ALTER TABLE TRAJECTE DISABLE CONSTRAINT FK_TRAJECTE_USUARICREADOR;
ALTER TABLE ESTACIO DISABLE CONSTRAINT FK_ESTACIO_CIUTAT;

TRUNCATE TABLE PARADA;
TRUNCATE TABLE TRAJECTE;
TRUNCATE TABLE ESTACIO;
TRUNCATE TABLE USUARI;
TRUNCATE TABLE MITJA_TRANSPORT;
TRUNCATE TABLE CIUTAT;

ALTER TABLE ESTACIO ENABLE CONSTRAINT FK_ESTACIO_CIUTAT;
ALTER TABLE TRAJECTE ENABLE CONSTRAINT FK_TRAJECTE_MITJATRANSPORT;
ALTER TABLE TRAJECTE ENABLE CONSTRAINT FK_TRAJECTE_USUARICREADOR;
ALTER TABLE PARADA ENABLE CONSTRAINT FK_PARADA_TRAJECTE;
ALTER TABLE PARADA ENABLE CONSTRAINT FK_PARADA_ESTACIO;

PAUSE "TAULES BUIDADES I FK ACTIVADES"


-- CIUTATS
INSERT INTO CIUTAT (nom) VALUES ('Barcelona');
INSERT INTO CIUTAT (nom) VALUES ('Girona');
INSERT INTO CIUTAT (nom) VALUES ('Figueres');
INSERT INTO CIUTAT (nom) VALUES ('Igualada');
INSERT INTO CIUTAT (nom) VALUES ('Martorell');
INSERT INTO CIUTAT (nom) VALUES ('Manresa');
INSERT INTO CIUTAT (nom) VALUES ('Sant Cugat del Vallès');
INSERT INTO CIUTAT (nom) VALUES ('Terrassa');
INSERT INTO CIUTAT (nom) VALUES ('Mataró');
INSERT INTO CIUTAT (nom) VALUES ('Blanes');
INSERT INTO CIUTAT (nom) VALUES ('Sitges');
INSERT INTO CIUTAT (nom) VALUES ('Vilanova i la Geltrú');
INSERT INTO CIUTAT (nom) VALUES ('Tarragona');
INSERT INTO CIUTAT (nom) VALUES ('Reus');
INSERT INTO CIUTAT (nom) VALUES ('Banyoles');
INSERT INTO CIUTAT (nom) VALUES ('Olot');
INSERT INTO CIUTAT (nom) VALUES ('Lleida');
INSERT INTO CIUTAT (nom) VALUES ('Mollerussa');
INSERT INTO CIUTAT (nom) VALUES ('Cervera');
INSERT INTO CIUTAT (nom) VALUES ('Granollers');

PAUSE "CIUTATS INSERTADES"

-- TRANSPORT
INSERT INTO MITJA_TRANSPORT (nom) VALUES ('Renfe');
INSERT INTO MITJA_TRANSPORT (nom) VALUES ('FGC');
INSERT INTO MITJA_TRANSPORT (nom) VALUES ('TMB');
INSERT INTO MITJA_TRANSPORT (nom) VALUES ('Sagalés');
INSERT INTO MITJA_TRANSPORT (nom) VALUES ('TEISA');
INSERT INTO MITJA_TRANSPORT (nom) VALUES ('ALSA');
INSERT INTO MITJA_TRANSPORT (nom) VALUES ('Hife');
INSERT INTO MITJA_TRANSPORT (nom) VALUES ('Monbus');
INSERT INTO MITJA_TRANSPORT (nom) VALUES ('Avanza');
INSERT INTO MITJA_TRANSPORT (nom) VALUES ('FlixBus');

PAUSE "EMPRESES INSERTADES"

-- USUARIS
INSERT INTO USUARI (email, nom, password, tipus, dataRegistre) VALUES ('marc.serra@projecte.test', 'Marc Serra', 'DemoPass01!', 'A', TO_DATE('2026-09-01', 'YYYY-MM-DD'));
INSERT INTO USUARI (email, nom, password, tipus, dataRegistre) VALUES ('julia.puig@projecte.test', 'Júlia Puig', 'DemoPass02!', 'A', TO_DATE('2026-09-02', 'YYYY-MM-DD'));
INSERT INTO USUARI (email, nom, password, tipus, dataRegistre) VALUES ('pau.soler@projecte.test', 'Pau Soler', 'DemoPass03!', 'E', TO_DATE('2026-09-03', 'YYYY-MM-DD'));
INSERT INTO USUARI (email, nom, password, tipus, dataRegistre) VALUES ('laia.vila@projecte.test', 'Laia Vila', 'DemoPass04!', 'E', TO_DATE('2026-09-04', 'YYYY-MM-DD'));
INSERT INTO USUARI (email, nom, password, tipus, dataRegistre) VALUES ('arnau.roca@projecte.test', 'Arnau Roca', 'DemoPass05!', 'E', TO_DATE('2026-09-05', 'YYYY-MM-DD'));
INSERT INTO USUARI (email, nom, password, tipus, dataRegistre) VALUES ('claudia.costa@projecte.test', 'Clàudia Costa', 'DemoPass06!', 'E', TO_DATE('2026-09-06', 'YYYY-MM-DD'));
INSERT INTO USUARI (email, nom, password, tipus, dataRegistre) VALUES ('pol.pons@projecte.test', 'Pol Pons', 'DemoPass07!', 'E', TO_DATE('2026-09-07', 'YYYY-MM-DD'));
INSERT INTO USUARI (email, nom, password, tipus, dataRegistre) VALUES ('marta.ferrer@projecte.test', 'Marta Ferrer', 'DemoPass08!', 'E', TO_DATE('2026-09-08', 'YYYY-MM-DD'));
INSERT INTO USUARI (email, nom, password, tipus, dataRegistre) VALUES ('nil.marti@projecte.test', 'Nil Martí', 'DemoPass09!', 'E', TO_DATE('2026-09-09', 'YYYY-MM-DD'));
INSERT INTO USUARI (email, nom, password, tipus, dataRegistre) VALUES ('aina.font@projecte.test', 'Aina Font', 'DemoPass10!', 'E', TO_DATE('2026-09-10', 'YYYY-MM-DD'));
INSERT INTO USUARI (email, nom, password, tipus, dataRegistre) VALUES ('oriol.sala@projecte.test', 'Oriol Sala', 'DemoPass11!', 'E', TO_DATE('2026-09-11', 'YYYY-MM-DD'));
INSERT INTO USUARI (email, nom, password, tipus, dataRegistre) VALUES ('marina.bosch@projecte.test', 'Marina Bosch', 'DemoPass12!', 'B', TO_DATE('2026-09-12', 'YYYY-MM-DD'));

PAUSE "USUARIS INSERTATS"

-- ESTACIONS
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Barcelona Sants', 41.379100, 2.140100, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Barcelona')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Barcelona Plaça Espanya FGC', 41.375000, 2.149000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Barcelona')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Barcelona Plaça Catalunya FGC', 41.387000, 2.169900, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Barcelona')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Barcelona Clot-Aragó', 41.409100, 2.187500, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Barcelona')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Granollers Centre', 41.606000, 2.287000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Granollers')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Girona', 41.979400, 2.816900, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Girona')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Figueres', 42.266600, 2.961800, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Figueres')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Martorell Central FGC', 41.474000, 1.930000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Martorell')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Igualada FGC', 41.578800, 1.617200, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Igualada')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Manresa Alta FGC', 41.732000, 1.826000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Manresa')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Sant Cugat FGC', 41.472000, 2.085000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Sant Cugat del Vallès')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Terrassa Rambla FGC', 41.563700, 2.008800, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Terrassa')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Mataró', 41.538000, 2.445000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Mataró')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Blanes', 41.674000, 2.790000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Blanes')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Sitges', 41.238000, 1.810000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Sitges')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Vilanova i la Geltrú', 41.224000, 1.725000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Vilanova i la Geltrú')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Tarragona', 41.111600, 1.253500, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Tarragona')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Reus', 41.160000, 1.106000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Reus')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Estació d''Autobusos de Banyoles', 42.118000, 2.765000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Banyoles')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Estació d''Autobusos d''Olot', 42.182000, 2.489000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Olot')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Lleida-Pirineus', 41.620700, 0.632600, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Lleida')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Mollerussa', 41.629000, 0.895000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Mollerussa')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Cervera', 41.670000, 1.272000, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Cervera')));
INSERT INTO ESTACIO (nom, latitud, longitud, id_ciutat) VALUES ('Estació d''Autobusos de Girona', 41.979100, 2.817700, (SELECT id FROM CIUTAT WHERE UPPER(nom) = UPPER('Girona')));

PAUSE "ESTACIONS INSERTADES"

-- TRAJECTES
INSERT INTO TRAJECTE (nom, dataCreacio, validat, mitjaTransport, usuariCreador) VALUES ('Barcelona - Girona', TO_DATE('2026-09-15', 'YYYY-MM-DD'), 1, (SELECT id FROM MITJA_TRANSPORT WHERE UPPER(nom) = UPPER('Renfe')), (SELECT id FROM USUARI WHERE UPPER(email) = UPPER('pau.soler@projecte.test')));
INSERT INTO TRAJECTE (nom, dataCreacio, validat, mitjaTransport, usuariCreador) VALUES ('Barcelona - Figueres', TO_DATE('2026-09-16', 'YYYY-MM-DD'), 1, (SELECT id FROM MITJA_TRANSPORT WHERE UPPER(nom) = UPPER('Renfe')), (SELECT id FROM USUARI WHERE UPPER(email) = UPPER('laia.vila@projecte.test')));
INSERT INTO TRAJECTE (nom, dataCreacio, validat, mitjaTransport, usuariCreador) VALUES ('Barcelona - Igualada', TO_DATE('2026-09-17', 'YYYY-MM-DD'), 1, (SELECT id FROM MITJA_TRANSPORT WHERE UPPER(nom) = UPPER('FGC')), (SELECT id FROM USUARI WHERE UPPER(email) = UPPER('arnau.roca@projecte.test')));
INSERT INTO TRAJECTE (nom, dataCreacio, validat, mitjaTransport, usuariCreador) VALUES ('Barcelona - Manresa', TO_DATE('2026-09-18', 'YYYY-MM-DD'), 1, (SELECT id FROM MITJA_TRANSPORT WHERE UPPER(nom) = UPPER('FGC')), (SELECT id FROM USUARI WHERE UPPER(email) = UPPER('claudia.costa@projecte.test')));
INSERT INTO TRAJECTE (nom, dataCreacio, validat, mitjaTransport, usuariCreador) VALUES ('Barcelona - Terrassa', TO_DATE('2026-09-19', 'YYYY-MM-DD'), 1, (SELECT id FROM MITJA_TRANSPORT WHERE UPPER(nom) = UPPER('FGC')), (SELECT id FROM USUARI WHERE UPPER(email) = UPPER('pol.pons@projecte.test')));
INSERT INTO TRAJECTE (nom, dataCreacio, validat, mitjaTransport, usuariCreador) VALUES ('Barcelona - Blanes', TO_DATE('2026-09-20', 'YYYY-MM-DD'), 1, (SELECT id FROM MITJA_TRANSPORT WHERE UPPER(nom) = UPPER('Renfe')), (SELECT id FROM USUARI WHERE UPPER(email) = UPPER('marta.ferrer@projecte.test')));
INSERT INTO TRAJECTE (nom, dataCreacio, validat, mitjaTransport, usuariCreador) VALUES ('Barcelona - Vilanova i la Geltrú', TO_DATE('2026-09-21', 'YYYY-MM-DD'), 1, (SELECT id FROM MITJA_TRANSPORT WHERE UPPER(nom) = UPPER('Renfe')), (SELECT id FROM USUARI WHERE UPPER(email) = UPPER('nil.marti@projecte.test')));
INSERT INTO TRAJECTE (nom, dataCreacio, validat, mitjaTransport, usuariCreador) VALUES ('Barcelona - Reus', TO_DATE('2026-09-22', 'YYYY-MM-DD'), 1, (SELECT id FROM MITJA_TRANSPORT WHERE UPPER(nom) = UPPER('Renfe')), (SELECT id FROM USUARI WHERE UPPER(email) = UPPER('aina.font@projecte.test')));
INSERT INTO TRAJECTE (nom, dataCreacio, validat, mitjaTransport, usuariCreador) VALUES ('Girona - Olot', TO_DATE('2026-09-23', 'YYYY-MM-DD'), 1, (SELECT id FROM MITJA_TRANSPORT WHERE UPPER(nom) = UPPER('TEISA')), (SELECT id FROM USUARI WHERE UPPER(email) = UPPER('oriol.sala@projecte.test')));
INSERT INTO TRAJECTE (nom, dataCreacio, validat, mitjaTransport, usuariCreador) VALUES ('Lleida - Cervera', TO_DATE('2026-09-24', 'YYYY-MM-DD'), 1, (SELECT id FROM MITJA_TRANSPORT WHERE UPPER(nom) = UPPER('FGC')), (SELECT id FROM USUARI WHERE UPPER(email) = UPPER('marina.bosch@projecte.test')));

PAUSE "TRAJECTES INSERTATS"

-- PARADES
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Girona')), 1, 'Barcelona Sants', '06:00', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Barcelona Sants')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Girona')), 2, 'Granollers Centre', '06:40', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Granollers Centre'))); --PODRIA FER TRANSBORD DE GRANOLLERS A FIGUERES
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Girona')), 3, 'Girona', '07:30', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Girona'))); 
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Figueres')), 1, 'Barcelona Sants', '07:00', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Barcelona Sants')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Figueres')), 2, 'Girona', '08:00', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Girona')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Figueres')), 3, 'Figueres', '08:35', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Figueres')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Igualada')), 1, 'Barcelona Plaça Espanya FGC', '08:00', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Barcelona Plaça Espanya FGC')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Igualada')), 2, 'Martorell Central FGC', '08:40', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Martorell Central FGC')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Igualada')), 3, 'Igualada FGC', '09:20', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Igualada FGC')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Manresa')), 1, 'Barcelona Plaça Espanya FGC', '09:00', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Barcelona Plaça Espanya FGC')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Manresa')), 2, 'Martorell Central FGC', '09:40', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Martorell Central FGC')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Manresa')), 3, 'Manresa Alta FGC', '10:30', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Manresa Alta FGC')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Terrassa')), 1, 'Barcelona Plaça Catalunya FGC', '10:00', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Barcelona Plaça Catalunya FGC')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Terrassa')), 2, 'Sant Cugat FGC', '10:30', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Sant Cugat FGC')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Terrassa')), 3, 'Terrassa Rambla FGC', '11:00', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Terrassa Rambla FGC')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Blanes')), 1, 'Barcelona Clot-Aragó', '11:00', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Barcelona Clot-Aragó')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Blanes')), 2, 'Mataró', '11:40', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Mataró')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Blanes')), 3, 'Blanes', '12:30', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Blanes')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Vilanova i la Geltrú')), 1, 'Barcelona Sants', '12:00', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Barcelona Sants')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Vilanova i la Geltrú')), 2, 'Sitges', '12:30', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Sitges')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Vilanova i la Geltrú')), 3, 'Vilanova i la Geltrú', '12:45', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Vilanova i la Geltrú')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Reus')), 1, 'Barcelona Sants', '13:00', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Barcelona Sants')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Reus')), 2, 'Tarragona', '14:00', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Tarragona')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Barcelona - Reus')), 3, 'Reus', '14:30', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Reus')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Girona - Olot')), 1, 'Estació d''Autobusos de Girona', '14:00', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Estació d''Autobusos de Girona')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Girona - Olot')), 2, 'Estació d''Autobusos de Banyoles', '14:40', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Estació d''Autobusos de Banyoles')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Girona - Olot')), 3, 'Estació d''Autobusos d''Olot', '15:20', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Estació d''Autobusos d''Olot')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Lleida - Cervera')), 1, 'Lleida-Pirineus', '15:00', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Lleida-Pirineus')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Lleida - Cervera')), 2, 'Mollerussa', '15:30', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Mollerussa')));
INSERT INTO PARADA (id_traj, ordre, nom, horaPas, idEstacio) VALUES ((SELECT id FROM TRAJECTE WHERE UPPER(nom) = UPPER('Lleida - Cervera')), 3, 'Cervera', '16:10', (SELECT id FROM ESTACIO WHERE UPPER(nom) = UPPER('Cervera')));

PAUSE "PARADES INSERTADES"

COMMIT;
