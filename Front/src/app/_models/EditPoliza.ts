import { Cobertura } from './Cobertura';

export interface EditPoliza {
   polizaId: number;
   marca: string;
   vehiculo: string;
   modelo: string;
   coberturasIdsList: Cobertura[];
}

/* 
{
  "polizaId": 37,
  "marca": "marca",
  "vehiculo": "2020",
  "modelo": "modelo",
  "coberturasIdsList": [ 2, 1, 3 ]
}
*/
