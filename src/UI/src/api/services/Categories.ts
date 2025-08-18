import type { Category } from "@/type/Category";
import { categoriesRepository } from "../repositories/Categories";

export const productsService = {
  async getAllCategories(): Promise<Category[]> {
    return await categoriesRepository.getAllCategories();
  },
};
