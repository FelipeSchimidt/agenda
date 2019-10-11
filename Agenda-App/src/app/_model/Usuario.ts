import { Evento } from './Evento';
import { Login } from './Login';

export interface Usuario {
	id: number;
	nome: string;
	sobrenome: string;
	nascimento: Date;
	cpf: string;
	email: string;
	imagemURL: string;
	eventos: Evento[];
	logins: Login[];
}
