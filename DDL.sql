CREATE TABLE Action(
	id VARCHAR(5) PRIMARY KEY, /* ACT01 */
	nom VARCHAR(255)
);

CREATE TABLE Joueur(
	id VARCHAR(4) PRIMARY KEY, /* J001 */
	nom VARCHAR(255),
	prenom VARCHAR(255)
);

CREATE TABLE Equipe(
	id VARCHAR(4) PRIMARY KEY, /* EQ01 */
	nom VARCHAR(255)
);

CREATE TABLE EquipeDetails(
	id VARCHAR(6) PRIMARY KEY, /* ED0001 */
	equipe VARCHAR(4),
	joueur VARCHAR(4),
	numero NUMERIC,
	FOREIGN KEY (equipe) REFERENCES Equipe(id),
	FOREIGN KEY (joueur) REFERENCES Joueur(id)
);

CREATE TABLE Partie(
	id VARCHAR(5) PRIMARY KEY, /* PT001 */
	datePartie DATETIME,
	equipe1 VARCHAR(4),
	equipe2 VARCHAR(4),
	dureeMitemps TIME,
	fini INT,
	FOREIGN KEY (equipe1) REFERENCES Equipe(id),
	FOREIGN KEY (equipe2) REFERENCES Equipe(id)
);

CREATE TABLE PartieDetails(
	partie VARCHAR(5),
	mitemps NUMERIC,
	temps TIME,
	equipe VARCHAR(4),
	details VARCHAR(6),
	action VARCHAR(5),
	remarque VARCHAR(255),
	FOREIGN KEY (partie) REFERENCES Partie(id),
	FOREIGN KEY (equipe) REFERENCES Equipe(id),
	FOREIGN KEY (details) REFERENCES EquipeDetails(id),
	FOREIGN KEY (action) REFERENCES Action(id)
);

CREATE TABLE Possession(
	partie VARCHAR(5),
	mitemps NUMERIC,
	equipe VARCHAR(4),
	details VARCHAR(6),
	duree TIME,
	FOREIGN KEY (partie) REFERENCES Partie(id),
	FOREIGN KEY (equipe) REFERENCES Equipe(id),
	FOREIGN KEY (details) REFERENCES EquipeDetails(id)
);

CREATE TABLE ProchainePartie(
	id VARCHAR(5) PRIMARY KEY, /* PP001 */
	equipe1 VARCHAR(4),
	equipe2 VARCHAR(4),
	partie VARCHAR(5),
	FOREIGN KEY (equipe1) REFERENCES Equipe(id),
	FOREIGN KEY (equipe2) REFERENCES Equipe(id),
	FOREIGN KEY (partie) REFERENCES Partie(id)
);

CREATE TABLE Client(
	id VARCHAR(5) PRIMARY KEY, /* CL001 */
	pseudo VARCHAR(255),
	password VARCHAR(255),
	solde FLOAT
);

CREATE TABLE Sequence(
	name VARCHAR(255) PRIMARY KEY NOT NULL,
	val INTEGER,
	fill INTEGER,
	pref VARCHAR(5)
);

CREATE TABLE SeqVal(
	nom VARCHAR(255) PRIMARY KEY,
	valeur INT
);

/* RATTRAPAGE */

CREATE TABLE Pari(
	id VARCHAR(8) PRIMARY KEY, /* PA000001 */
	client VARCHAR(5),
	partie VARCHAR(5),
	typePari INT,
	action VARCHAR(5),
	equilibre INT,
	regleEgalite INT,
	FOREIGN KEY (client) REFERENCES Client(id),
	FOREIGN KEY (partie) REFERENCES ProchainePartie(id),
	FOREIGN KEY (action) REFERENCES Action(id)
);

CREATE TABLE PariDetail(
	id VARCHAR(9) PRIMARY KEY, /* PAD000001 */
	pari VARCHAR(8),
	equipe VARCHAR(4),
	compensation INT,
	montant FLOAT,
	ecartMax FLOAT,
	ecart FLOAT,
	montantEcart FLOAT,
	FOREIGN KEY (pari) REFERENCES Pari(id),
	FOREIGN KEY (equipe) REFERENCES Equipe(id)
);

CREATE TABLE Jonction(
	id VARCHAR(8) PRIMARY KEY, /* J0000001 */
	pari VARCHAR(9),
	contrePari VARCHAR(9),
	montant FLOAT,
	regle INT,
	FOREIGN KEY (pari) REFERENCES PariDetail(id),
	FOREIGN KEY (contrePari) REFERENCES PariDetail(id)
);

CREATE TABLE Pret(
	id VARCHAR(8) PRIMARY KEY, /* PR000001 */
	client VARCHAR(5),
	montant FLOAT,
	datePret DATETIME,
	rembourse INT,
	FOREIGN KEY (client) REFERENCES Client(id)
);

CREATE TABLE Remboursement(
	id VARCHAR(8) PRIMARY KEY, /* R0000001 */
	pret VARCHAR(8),
	dateRemboursement DATETIME,
	montant FLOAT,
	interet FLOAT,
	fait INT,
	FOREIGN KEY (pret) REFERENCES Pret(id)
);

CREATE TABLE Taux(
	id VARCHAR(4) PRIMARY KEY, /* TA01 */
	nom VARCHAR(30), /* interet */
	valeur FLOAT /* 5% */
);

-- VIEW :

CREATE VIEW ViewStat AS
SELECT partie, mitemps, equipe, details, action, COUNT(action) as nombre
FROM PartieDetails 
GROUP BY partie, mitemps, equipe, details, action;

-- FUNCTION :

CREATE FUNCTION Rembourse(@pret VARCHAR(8)) RETURNS INT AS BEGIN
	DECLARE @retour INT
	
	IF (SELECT COUNT(*) FROM Remboursement WHERE pret=@pret AND fait=1) = (SELECT COUNT(*) FROM Remboursement WHERE pret=@pret)
		SET @retour = 1
	ELSE
		SET @retour = 0
		
	RETURN @retour
END

CREATE FUNCTION GetDetail(@partie VARCHAR(5), @equipe VARCHAR(4), @action VARCHAR(5)) RETURNS INT AS BEGIN
	DECLARE @retour INT
	
	SELECT @retour=COUNT(*) FROM PartieDetails WHERE partie=@partie AND equipe=@equipe AND action=@action
	
	RETURN @retour
END

-- TRIGGER :

CREATE TRIGGER VerifRemb ON Remboursement AFTER UPDATE AS
BEGIN
	SET NOCOUNT ON
	DECLARE @idPret VARCHAR(8)
	SELECT @idPret=i.pret FROM inserted i
	IF dbo.Rembourse(@idPret) = 1
		UPDATE Pret SET rembourse=1 WHERE id=@idPret
END

















