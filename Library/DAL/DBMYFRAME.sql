drop database DBMYFRAME
GO
create database DBMYFRAME
GO
use DBMYFRAME
GO

create table TGESTOR (
	GEIDGESTOR      int not null identity(1,1) primary key,
	GENMGESTOR 	    varchar(100),
	GEDTNASCGESTOR  date
);
GO

create table TTURMA (
	TUIDTURMA   int not null identity(1,1) primary key,
	TUNMTURMA   varchar(50)
);
GO

create table TAVALIACAOCRITERIO (
	AVCRIDAVCR   int not null identity(1,1) primary key,
	AVCRDESCAVCR int,
);
GO

create table TITENSTURMA (
	ITTUIDITTU   int not null identity(1,1) primary key,
	ITTUDESCITTU varchar(100),
);
GO

create table TEVENTO (
	EVIDEVENTO		int not null identity(1,1) primary key,
	EVNMEVENTO		varchar(50),
	EVENDEVENTO		varchar(200),
	EVDTEVENTO		date,
	EVDESCEVENTO	varchar(200),
	EVCAPAMAXEVENTO varchar(50),

	GEIDGESTOR  int constraint EV_IDGESTOR_FK foreign key(GEIDGESTOR) references TGESTOR(GEIDGESTOR)
);
GO

create table TVISITANTE (
	VIIDVISI	   int not null identity(1,1) primary key,
	VINMVISI       varchar(100),
	VICPFVISI      varchar(15),
	VICIDAVISI     varchar(200),
	VIEMAILVISI    varchar(50),
	VINASCVISI     date,
	
	EVIDEVENTO int constraint VISI_IDEVENTO_FK foreign key(EVIDEVENTO) references TEVENTO(EVIDEVENTO)
);
GO

create table TPROJETO (
	PROIDPROJ	 int not null identity(1,1) primary key,
	PRONMPROJ	 varchar(100),
	PROLOCPROJ   varchar(100),
	PRODTPROJ	 date,
	PRODESCPROJ  varchar(100),

	EVIDEVENTO int constraint PROJ_IDEVENTO_FK foreign key(EVIDEVENTO) references TEVENTO(EVIDEVENTO)
);
GO

CREATE TABLE TAVALIACAO 
(
	AVIDVISI	  int,
	AVIDCRITAVA	  int,
	AVIDPROJ	  int,
	AVNOTAAVA	  varchar(20),
	AVDATAAVA	  date,
	AVFEEDBACKAVA varchar(500)

	 constraint AV_PROJ_FK primary key (AVIDCRITAVA, AVIDPROJ, AVIDVISI) 
);
GO

create table TPROJCRIAVA (
	PCAIDPROJ int constraint PCA_IDPROJ_FK	foreign key(PCAIDPROJ)  references TPROJETO(PROIDPROJ),
	PCAIDCRAV int constraint PCA_IDCRAV_FK  foreign key(PCAIDCRAV)  references TAVALIACAOCRITERIO(AVCRIDAVCR)
);
GO

create table TTURITETUR (
	TITIDTURMA int constraint TIT_IDTURMA_FK  foreign key(TITIDTURMA)  references TTURMA(TUIDTURMA),
	TITIDITTU  int constraint TIT_IDITTU_FK   foreign key(TITIDITTU)   references TITENSTURMA(ITTUIDITTU)
);
GO

create table TPROJTUR (
	PTIDPROJ  int constraint PT_IDPROJ_FK   foreign key(PTIDPROJ)   references TPROJETO(PROIDPROJ),
	PTIDTURMA int constraint PT_IDTURMA_FK  foreign key(PTIDTURMA)	references TTURMA(TUIDTURMA)
);

/*INSERT'S*/

/*GESTOR*/
insert into TGESTOR 
	values('gestor','2020-01-01'),
		  ('gestor2','2020-01-02')

select * from TGESTOR

/*TURMA*/
insert into TTURMA 
	values('turma'),
		  ('turma2')

select * from TTURMA

/*AVALIACAOCRITERIO*/
insert into TAVALIACAOCRITERIO
	values(21),
		  (22)

select * from TAVALIACAOCRITERIO

/*ITENSTURMA*/
insert into TITENSTURMA
	values('itensturma'),
		  ('itensturma2')

select * from TITENSTURMA

/*EVENTO*/
insert into TEVENTO (EVNMEVENTO, EVENDEVENTO, EVDTEVENTO, EVDESCEVENTO, EVCAPAMAXEVENTO)
	values('evento','2 evento','2020-01-01','3 evento','4 evento'),
		  ('evento2','5 evento','2020-01-02','6 evento','7 evento')

select * from TEVENTO
drop TABLE TAVALIACAO

/*VISITANTE*/
insert into TVISITANTE (VINMVISI,VICPFVISI,VICIDAVISI,VIEMAILVISI,VINASCVISI)
	values('visitante','2 visitante','3 visitante','4 visitante','2020-01-01'),
		  ('visitante2','5 visitante','6 visitante','7 visitante','2020-01-02')

select * from TVISITANTE

/*AVALIACAO*/
insert into TAVALIACAO (AVIDVISI, AVIDCRITAVA, AVIDPROJ, AVNOTAAVA, AVDATAAVA, AVFEEDBACKAVA)
	values(1,1,1,'avaliacao','2020-01-01','2 avaliacao'),
		  (2,2,2,'valiacao2','2020-01-02', '3 avaliacao')

select * from TAVALIACAO