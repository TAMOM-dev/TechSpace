import type { Product } from "@/type/Product";
import { productsRepository } from "../repositories/Products";
import type { ProductInputs, ProductUpdateInputs } from "@/type/Admin";

export const productsService = {
  async getAllProducts(): Promise<Product[]> {
    return await productsRepository.getAllProducts();
  },
  async addProduct(product: ProductInputs): Promise<boolean> {
    const response = await productsRepository.addProduct(product);

    const { success } = response;

    if (!success) {
      throw new Error(response.message);
    }

    return success;
  },
  async updateProduct(product: ProductUpdateInputs) {
    return await productsRepository.updateProduct(product);
  },
  async deleteProduct(productId: string) {
    return await productsRepository.deleteProduct(productId);
  },
};
