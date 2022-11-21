export interface Brand {
  id?: number,
  name: string,
  country:string
}

export interface ResultListBrand{

  totalCount: number,
  result: Brand[]
}
