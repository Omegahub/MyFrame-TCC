drop database DBMYFRAME

create database DBMYFRAME

use DBMYFRAME

create table Gestor (
	idGestor     int not null identity(1,1) primary key,
	nomeGestor	 varchar(100),
	dtNascGestor date
);

create table Turma (
	idTurma   int not null identity(1,1) primary key,
	nomeCurso varchar(50)
);

create table AvaliacaoCriterio (
	idCriterioAv int not null identity(1,1) primary key,
	dsCriterioAv int,
);

create table ItensTurma (
	idItemTurma int not null identity(1,1) primary key,
	descItem	varchar(100),
);

create table Evento (
	idEvento		int not null identity(1,1) primary key,
	nomeEvento		varchar(50),
	endEvento		varchar(200),
	dtEvento		date,
	descEvento		varchar(200),
	capaciMaxEvento varchar(50),

	gestorIdGestor  int constraint fk_Gestor_idGestor foreign key(gestorIdGestor) references Gestor(idGestor)
);


CREATE TABLE TEVENTO
(
	EVIDEVENTO
	EVNOMEEVENTO
)

create table Visitante (
	idVisitante	   int not null identity(1,1) primary key,
	nomeVisitante  varchar(100),
	cpfVisitante   varchar(15),
	cidaVisitante  varchar(200),
	emailVisitante varchar(50),
	nascVisitante  date,

	eventoIdEvento int constraint fk_Evento_idEvento foreign key(eventoIdEvento) references Evento(idEvento)
);

create table Projeto (
	idProjeto	 int not null identity(1,1) primary key,
	nomeProjeto	 varchar(100),
	localProjeto varchar(100),
	dtProjeto	 date,
	descProjeto  varchar(100),

	eventoIdEvento int constraint fk2_Evento_idEvento foreign key(eventoIdEvento) references Evento(idEvento)
);

CREATE TABLE TAVALIACAO 
(
	AVIDVISI		INT			NOT NULL,
	AVIDCRITAVA		INT			NOT NULL,
	AVIDPROJ		INT			NOT NULL,
	AVNOTAAVA		VARCHAR(2)	NOT NULL,
	AVDATAAVA		DATETIME,
	AVFEEDBACKAVA	VARCHAR(500)

	CONSTRAINT AV_PROJ_FK PRIMARY KEY (AVIDCRITAVA, AVIDPROJ, AVIDVISI)
);

create table Projeto_CriterioAvaliacao (
	projetoIdProjeto	   int constraint fk_Projeto_idProjeto		 foreign key(projetoIdProjeto)		 references Projeto(idProjeto),
	criterioAvIdCriterioAv int constraint fk_CriterioAv_idCriterioAv foreign key(criterioAvIdCriterioAv) references CriterioAvaliacao(idCriterioAv)
);

create table Turma_ItemTurma (
	turmaIdTurma		 int constraint fk_Turma_idTurma		 foreign key(turmaIdTurma)		   references Turma(idTurma),
	itemTurmaIdItemTurma int constraint fk_ItemTurma_idItemTurma foreign key(itemTurmaIdItemTurma) references ItensTurma(idItemTurma)
);

create table Projeto_Turma (
	projetoIdProjeto int constraint fk2_Projeto_idProjeto foreign key(projetoIdProjeto) references Projeto(idProjeto),
	turmaIdTurma	 int constraint fk2_Turma_idTurma	 foreign key(turmaIdTurma)	   references Turma(idTurma)
);

