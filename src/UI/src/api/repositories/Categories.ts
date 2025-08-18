import type { Category } from "@/type/Category";
import { categoriesApi } from "./Index";

export const categoriesRepository = {
  async getAllCategories() {
    const { data } = await categoriesApi.get<Category[]>("/all");
    return data;
  },
};
