export interface Evento {
	id: number;
	nome: string;
	descricao: string;
	dataEvento?: Date;
	UsuarioId?: number;
}
