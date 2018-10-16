export interface ICrudService<T> {

  create(entity: T);
  update(entity: T);
  findAll(page: number, count: number);
  findById(id: number);
  delete(id: number);

}
