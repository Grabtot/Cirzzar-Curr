import { ApiProductsRoutes } from "./ApiProductsRoutes";

export const getAllProducts = async () => {
  const response = await fetch(ApiProductsRoutes.AllProducts);
  const data = await response.json();
  return data;
};

export const getPizzaProducts = async () => {
  const response = await fetch(ApiProductsRoutes.Pizza);
  const data = await response.json();
  return data;
};

export const getPizzaIngredients = async () => {
  const response = await fetch(ApiProductsRoutes.Ingredients);
  const data = await response.json();
  return data;
}

export const getProductById = async (id) => {
  const response = await fetch(`${ApiProductsRoutes.AllProducts}/${id}`);
  const data = await response.json();
  return data;
};

export const addProduct = async (product) => {
  const response = await fetch(ApiProductsRoutes.AllProducts, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(product),
  });
  const data = await response.json();
  return data;
};

export const addIngredient = async (ingredient) => {
  const response = await fetch(ApiProductsRoutes.Ingredients, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(ingredient),
  });
  const data = await response.json();
  return data;
};

export const updateProduct = async (product) => {
  const response = await fetch(ApiProductsRoutes.AllProducts, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(product),
  });
  const data = await response.json();
  return data;
};

export const deleteProduct = async (id) => {
  await fetch(`${ApiProductsRoutes.AllProducts}/${id}`, {
    method: "DELETE",
  });
};
