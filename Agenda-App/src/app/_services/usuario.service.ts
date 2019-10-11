import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../_model/Usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

	baseURL = 'http://localhost:5000/api/usuario';

	constructor(private http: HttpClient) { }

	geAlltUsuario(): Observable<Usuario[]> {
		return this.http.get<Usuario[]> (this.baseURL);
	}

	getUsuarioByName(nome: string): Observable<Usuario[]> {
		return this.http.get<Usuario[]> (`${this.baseURL}/getByName/${nome}`);
	}

	getUsuarioById(id: number): Observable<Usuario> {
		return this.http.get<Usuario> (`${this.baseURL}/${id}`);
	}

}
