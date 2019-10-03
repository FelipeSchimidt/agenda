import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-usuarios",
  templateUrl: "./usuarios.component.html",
  styleUrls: ["./usuarios.component.css"]
})
export class UsuariosComponent implements OnInit {
  usuarios: any = [];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;

  newVariable: any;

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

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getEventos();
  }

  getEventos() {
    this.http.get("http://localhost:5000/api/usuario").subscribe(
      response => {
        this.usuarios = response;
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }

  alternarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }

  filtrarUsuarios(filtrarPor: string) {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.usuarios.filter(
      usuario =>
        usuario.firstName.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
}
