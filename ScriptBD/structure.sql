create table team(
	id serial not null primary key,
	name varchar(50) not null,
	description varchar(150)
);

create table tournament(
	id serial not null primary key,
	name varchar(50) not null,
	number_teams int not null,
	number_phases int not null
);

create table phase(
	id serial not null primary key,
	id_tournament int not null,
	number_phase int not null,
	closed boolean not null
);
alter table phase add constraint fk1_phase foreign key (id_tournament) references tournament(id);

create table match(
	id serial not null primary key,
	number_match int not null,
	id_first_team int,
	id_second_team int,
	id_winner_team int,
	id_phase int not null
);
alter table match add constraint fk1_match foreign key (id_first_team) references team(id);
alter table match add constraint fk2_match foreign key (id_second_team) references team(id);
alter table match add constraint fk3_match foreign key (id_winner_team) references team(id);
alter table match add constraint fk4_match foreign key (id_phase) references phase(id);