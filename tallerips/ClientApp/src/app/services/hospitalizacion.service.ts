import { Injectable, Inject } from '@angular/core';
import { Hospitalizacion } from '../Copago/models/hospitalizacion';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';

@Injectable({
  providedIn: 'root'
})
export class HospitalizacionService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
      @Inject('BASE_URL') baseUrl: string,
      private handleErrorService: HandleHttpErrorService) 
      { 
        this.baseUrl = baseUrl;
      }

      get(): Observable<Hospitalizacion[]> {
        return this.http.get<Hospitalizacion[]>(this.baseUrl + 'api/Hospitalizacion')
            .pipe(
                tap(_ => this.handleErrorService.log('datos enviados')),
                catchError(this.handleErrorService.handleError<Hospitalizacion[]>('Consulta Hospitalizacion', null))
            );
      }
    
      post(hospitalizacion: Hospitalizacion): Observable<Hospitalizacion> {
        return this.http.post<Hospitalizacion>(this.baseUrl + 'api/Hospitalizacion', hospitalizacion)
            .pipe(
                tap(_ => this.handleErrorService.log('datos enviados')),
                catchError(this.handleErrorService.handleError<Hospitalizacion>('Registrar Hospitalizacion', null))
            );
    }
}
