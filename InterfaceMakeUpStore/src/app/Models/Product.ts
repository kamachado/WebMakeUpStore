export interface Product{

  id?: number,
  name: string,
  description:string,
  type:string,
  bodyPart: string,
  price:number,
  quantity:number,
  idBrand:number,
  photo:string
}

export interface ResultListProduct{

  totalCount: number,
  result: Product[]
}


export interface ProductData{
  id?: number,
  name: string,
  description:string,
  type:string,
  bodyPart: string,
  price:number,
  quantity:number,
  idBrand:number,
  photo:FormData
}




