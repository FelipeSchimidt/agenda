import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../_services/usuario.service';
import { Usuario } from '../_model/Usuario';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {
	usuarios: Usuario[];
	imagemLargura = 50;
	imagemMargem = 2;
	mostrarImagem = false;
	_filtroLista: string;

	get filtroLista() {
		return this._filtroLista;
	}
	set filtroLista(value: string) {
		this._filtroLista = value;
		this.usuariosFiltrados = this.filtroLista
		? this.filtrarUsuarios(this.filtroLista)
		: this.usuarios;
	}

  usuariosFiltrados: any = [];

  constructor(private usuarioService: UsuarioService) {}

	ngOnInit() {
		this.getEventos();
	}

	getEventos() {
		this.usuarioService.geAlltUsuario().subscribe(
		(_usuario: Usuario[]) => {
			this.usuarios = _usuario;
			this.usuariosFiltrados = this.usuarios;
			console.log(_usuario);
		},
		error => {
			console.log(error);
		}
		);
	}

	alternarImagem() {
		this.mostrarImagem = !this.mostrarImagem;
	}

	filtrarUsuarios(filtrarPor: string): Usuario[] {
		filtrarPor = filtrarPor.toLocaleLowerCase();
		return this.usuarios.filter(
		usuario =>
			usuario.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
		);
	}
}
