export interface Login {
	id: number;
	username: string;
	senha: string;
	createdAt: Date;
	updatedAt: Date;
	usuarioId?: number;
}
