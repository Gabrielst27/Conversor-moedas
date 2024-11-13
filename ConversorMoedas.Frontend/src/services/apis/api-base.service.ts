import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IMoeda } from '../moedas/interfaces/IMoeda.interface';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class BaseApi {
  protected baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {}

  getCotacaoAtual(codigo: string): Observable<IMoeda> {
    return this.http
      .get(`${this.baseUrl}api/Moeda/CotacaoAtual?codigo=${codigo}`)
      .pipe(
        map((response: any) => {
          return {
            id: response.id,
            nome: response.nome,
            precoCompra: response.precoCompra,
            precoVenda: response.precoVenda,
            cod: response.cod,
            data: response.data,
          } as IMoeda;
        })
      );
  }
}
