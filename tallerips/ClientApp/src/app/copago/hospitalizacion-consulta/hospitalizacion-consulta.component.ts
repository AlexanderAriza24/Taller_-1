import { Component, OnInit } from '@angular/core';
import { Hospitalizacion } from '../models/hospitalizacion';
import { HospitalizacionService } from 'src/app/services/hospitalizacion.service';

@Component({
  selector: 'app-hospitalizacion-consulta',
  templateUrl: './hospitalizacion-consulta.component.html',
  styleUrls: ['./hospitalizacion-consulta.component.css']
})
export class HospitalizacionConsultaComponent implements OnInit {

  hospitalizaciones:Hospitalizacion[];
  constructor(private hospitalizacionService: HospitalizacionService) { }

  ngOnInit() {

    this.hospitalizacionService.get().subscribe(result => {
      this.hospitalizaciones = result;
  });
  }

}
