import { ApiUserRoutes } from "./ApiUserRoutes";
import authService from "../api-authorization/AuthorizeService";

export const AddToCart = async (product) => {

  const token = await authService.getAccessToken();
  const headers = {
    "Content-Type": "application/json",
  };

  if (token) {
    headers["Authorization"] = `Bearer ${token}`;
  }
  const response = await fetch(ApiUserRoutes.User, {
    method: "PUT",
    headers: headers,
    body: JSON.stringify(product),
  });
  const text = await response.text();
  console.log("add to cart response:", text);
  const data = JSON.parse(text);
  return data;
};