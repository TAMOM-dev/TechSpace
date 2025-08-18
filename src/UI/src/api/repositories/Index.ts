import axios from "axios";

export const productsApi = axios.create({
  baseURL: `${import.meta.env.VITE_PUBLIC_API_URL}/api/Product`,
  headers: {
    "Content-Type": "application/json",
  },
});

export const categoriesApi = axios.create({
  baseURL: `${import.meta.env.VITE_PUBLIC_API_URL}/api/Category`,
  headers: {
    "Content-Type": "application/json",
  },
});
