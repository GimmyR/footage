/* ACTION */

INSERT INTO Action VALUES('ACT01', 'possession');
INSERT INTO Action VALUES('ACT02', 'passe');
INSERT INTO Action VALUES('ACT03', 'tir');
INSERT INTO Action VALUES('ACT04', 'tir cadre');
INSERT INTO Action VALUES('ACT05', 'but');

/* JOUEUR */

INSERT INTO Joueur VALUES('J001', 'Messi', 'Lionel');
INSERT INTO Joueur VALUES('J002', 'Ronaldo', 'Christiano');
INSERT INTO Joueur VALUES('J003', 'Dembele', 'Ousmane');
INSERT INTO Joueur VALUES('J004', 'Paulo', 'Jose');
INSERT INTO Joueur VALUES('J005', 'Suarez', 'Luis');
INSERT INTO Joueur VALUES('J006', 'Bale', 'Gareth');
INSERT INTO Joueur VALUES('J007', 'Benzema', 'Karim');
INSERT INTO Joueur VALUES('J008', 'Asensio', 'Marco');

/* EQUIPE */

INSERT INTO Equipe VALUES('EQ01', 'Barcelone');
INSERT INTO Equipe VALUES('EQ02', 'Real De Madrid');

/* EQUIPE DETAILS */

INSERT INTO EquipeDetails VALUES('ED0001', 'EQ01', 'J001', 10);
INSERT INTO EquipeDetails VALUES('ED0002', 'EQ02', 'J002', 7);
INSERT INTO EquipeDetails VALUES('ED0003', 'EQ01', 'J003', 11);
INSERT INTO EquipeDetails VALUES('ED0004', 'EQ01', 'J004', 15);
INSERT INTO EquipeDetails VALUES('ED0005', 'EQ01', 'J005', 9);
INSERT INTO EquipeDetails VALUES('ED0006', 'EQ02', 'J006', 11);
INSERT INTO EquipeDetails VALUES('ED0007', 'EQ02', 'J007', 9);
INSERT INTO EquipeDetails VALUES('ED0008', 'EQ02', 'J008', 20);

/* PARTIE */

INSERT INTO Partie VALUES('PT001', '2017-11-21', 'EQ01', 'EQ02', '00:00:40', 0);

/* PARTIE DETAILS */

INSERT INTO PartieDetails VALUES('PT001', 1, '00:00:00', 'EQ01', 'ED0001', 'ACT01', '');
INSERT INTO PartieDetails VALUES('PT001', 1, '00:00:30', 'EQ02', 'ED0002', 'ACT01', '');
INSERT INTO PartieDetails VALUES('PT001', 1, '00:00:40', 'EQ01', 'ED0001', 'ACT01', '');


/* POSSESSION */

INSERT INTO Possession VALUES('PT001', 1, 'EQ01', 'ED0001', '00:00:30');
INSERT INTO Possession VALUES('PT001', 1, 'EQ02', 'ED0002', '00:00:10');

/* CLIENT */

INSERT INTO Client VALUES('CL000', 'root', 'root', 0);
INSERT INTO Client VALUES('CL001', 'James', 'mdpJames', 1000);
INSERT INTO Client VALUES('CL002', 'Jason', 'mdpJason', 1000);

/* PROCHAINE PARTIE */

INSERT INTO ProchainePartie VALUES('PP001', 'EQ01', 'EQ02', NULL);

/* SEQUENCE */

INSERT INTO Sequence VALUES('action', 6, 2, 'ACT');
INSERT INTO Sequence VALUES('joueur', 9, 3, 'J');
INSERT INTO Sequence VALUES('equipe', 3, 2, 'EQ');
INSERT INTO Sequence VALUES('equipeDetails', 9, 4, 'ED');
INSERT INTO Sequence VALUES('partie', 2, 3, 'PT');

UPDATE Sequence SET val=6 WHERE name='action';

INSERT INTO SeqVal VALUES('seqAction', 4);
INSERT INTO SeqVal VALUES('seqJoueur', 3);
INSERT INTO SeqVal VALUES('seqEquipe', 3);
INSERT INTO SeqVal VALUES('seqEquipeDetails', 3);
INSERT INTO SeqVal VALUES('seqPartie', 2);
INSERT INTO SeqVal VALUES('seqClient', 3);
INSERT INTO SeqVal VALUES('seqProchainePartie', 1);
INSERT INTO SeqVal VALUES('seqPari', 1);
INSERT INTO SeqVal VALUES('seqPariDetail', 1);
INSERT INTO SeqVal VALUES('seqJonction', 1);
INSERT INTO SeqVal VALUES('seqPret', 1);
INSERT INTO SeqVal VALUES('seqRemboursement', 1);
INSERT INTO SeqVal VALUES('seqPenalite', 1);

UPDATE SeqVal SET valeur=1 WHERE nom='seqPret';

/* RATTRAPAGE */

INSERT INTO Taux VALUES('TA01', 'Interet', 5);
INSERT INTO Taux VALUES('TA02', 'Retard', 3);