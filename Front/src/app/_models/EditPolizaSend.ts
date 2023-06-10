export interface EditPolizaSend {
   polizaId: number;
   marca: string;
   vehiculo: string;
   modelo: string;
   coberturasIdsList: number[];
}

/* 
{
  "marca": "marca",
  "vehiculo": "2020",
  "modelo": "modelo",
  "coberturasIdsList": [ 2, 1, 3 ]
}
*/
/*        lo q sale pal edit

{
   "polizaId": 37,
   "marca": "marca",
   "vehiculo": "2020",
   "modelo": "modelo",
   "coberturasIdsList": [ 1, 3 ]
}
*/
