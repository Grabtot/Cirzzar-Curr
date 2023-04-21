const prefix = "/api/products";

export const ApiProductsRoutes = {
  AllProducts: prefix,
  ProductTypes: `${prefix}/types`,
  Pizza: `${prefix}/pizza`,
  Ingredients: `${prefix}/pizza/ingredients`,
};
