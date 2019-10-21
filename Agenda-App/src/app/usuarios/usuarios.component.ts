import { Component, OnInit, TemplateRef } from '@angular/core';
import { UsuarioService } from '../_services/usuario.service';
import { Usuario } from '../_model/Usuario';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import {
	FormGroup,
	FormControl,
	Validators,
	FormBuilder
} from '@angular/forms';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

	constructor(
			private usuarioService: UsuarioService,
		private modalService: BsModalService,
		private fb: FormBuilder
		) {}

	get filtroLista() {
		return this._filtroLista;
	}
	set filtroLista(value: string) {
		this._filtroLista = value;
		this.usuariosFiltrados = this.filtroLista
		? this.filtrarUsuarios(this.filtroLista)
		: this.usuarios;
	}
	usuarios: Usuario[];
	imagemLargura = 50;
	imagemMargem = 2;
	mostrarImagem = false;
	modalRef: BsModalRef;
	registerForm: FormGroup;

	_filtroLista: string;

  	usuariosFiltrados: any = [];

	openModal(template: TemplateRef<any>) {
		this.modalRef = this.modalService.show(template);
	}

	ngOnInit() {
		this.getEventos();
		this.validation();
	}

	getEventos() {
		this.usuarioService.geAlltUsuario().subscribe(
		(_usuario: Usuario[]) => {
			this.usuarios = _usuario;
			this.usuariosFiltrados = this.usuarios;
			console.table(_usuario);
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

	validation() {
		this.registerForm = this.fb.group({
			// tslint:disable-next-line: new-parens
			nome: [
				'',
				[
				Validators.required,
				Validators.minLength(4),
				Validators.maxLength(50)
				]
			],
			// tslint:disable-next-line: new-parens
			sobrenome: [
				'',
				[
				Validators.required,
				Validators.minLength(4),
				Validators.maxLength(50)
				]
			],
			// tslint:disable-next-line: new-parens
			nascimento: ['', [Validators.required]],
			// tslint:disable-next-line: new-parens
			cpf: ['', [Validators.required]],
			// tslint:disable-next-line: new-parens
			email: ['', [Validators.required, Validators.email]],
			// tslint:disable-next-line: new-parens
			imagemURL: ['', Validators.required]
		});
	}

	salvarAlteracao() {}
}
