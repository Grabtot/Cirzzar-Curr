import { ApiProductsRoutes } from "./ApiProductsRoutes";
import authService from "../api-authorization/AuthorizeService";

export const getAllProducts = async () => {
  const response = await fetch(ApiProductsRoutes.AllProducts);
  const text = await response.text();
  console.log("getAllProducts response:", text);
  const data = JSON.parse(text);
  return data;
};

export const getProductTypes = async () => {
  const response = await fetch(ApiProductsRoutes.ProductTypes);
  const text = await response.text();
  console.log("getProductTypes response:", text);
  const data = JSON.parse(text);
  return data;
}

export const getPizzaProducts = async () => {
  const response = await fetch(ApiProductsRoutes.Pizza);
  const text = await response.text();
  console.log("getPizzaProducts response:", text);
  const data = JSON.parse(text);
  return data;
};
export const getPizzaIngredients = async () => {
  try {
    const response = await fetch(ApiProductsRoutes.Ingredients);

    // Проверяем, является ли ответ сервера успешным
    if (!response.ok) {
      // Выводим текст ответа для анализа проблемы
      const text = await response.text();
      console.error('Server response:', text);
      throw new Error(`Error getting pizza ingredients: ${response.status}`);
    }

    const data = await response.json();
    return data;
  } catch (error) {
    console.error('Error getting pizza ingredients:', error);
    throw error;
  }
};

export const getProductById = async (id) => {
  const response = await fetch(`${ApiProductsRoutes.AllProducts}/${id}`);
  const text = await response.text();
  console.log("getProductById response:", text);
  const data = JSON.parse(text);
  return data;
};

export const addProduct = async (product) => {
  const token = await authService.getAccessToken();
  const headers = {
    "Content-Type": "application/json",
  };

  if (token) {
    headers["Authorization"] = `Bearer ${token}`;
  }

  const response = await fetch(ApiProductsRoutes.AllProducts, {
    method: "POST",
    headers: headers,
    body: JSON.stringify(product),
  });
  const text = await response.text();
  console.log("addProduct response:", text);
  const data = JSON.parse(text);
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
  const text = await response.text();
  console.log("addIngredient response:", text);
  const data = JSON.parse(text);
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
  const text = await response.text();
  console.log("updateProduct response:", text);
  const data = JSON.parse(text);
  return data;
};

export const deleteProduct = async (id) => {
  const token = await authService.getAccessToken();
  const headers = {};

  if (token) {
    headers["Authorization"] = `Bearer ${token}`;
  }
  const response = await fetch(`${ApiProductsRoutes.AllProducts}/${id}`, {
    method: "DELETE",
    headers: headers
  });
  const text = await response.text();
  console.log("deleteProduct response:", text);
};