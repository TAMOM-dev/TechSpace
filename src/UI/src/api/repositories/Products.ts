import type { Product } from "@/type/Product";
import { productsApi } from "./Index";
import type {
  AddProduct,
  ProductInputs,
  ProductUpdateInputs,
} from "@/type/Admin";

export const productsRepository = {
  async getAllProducts() {
    const { data } = await productsApi.get<Product[]>("/");
    return data;
  },
  async addProduct(product: ProductInputs) {
    const { data } = await productsApi.post<AddProduct>("/", {
      ...product,
      categoryId: "b2c3d4e5-f6a7-48b9-1c2d-3e4f5a6b7c8d",
    });
    return data;
  },
  async updateProduct(product: ProductUpdateInputs) {
    const { data } = await productsApi.put("/", product);
    return data;
  },
  async deleteProduct(productId: string) {
    const { data } = await productsApi.delete("/", {
      params: { id: productId },
    });

    return data;
  },
};
