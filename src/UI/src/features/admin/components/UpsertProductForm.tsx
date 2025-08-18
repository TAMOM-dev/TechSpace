import type { ProductInputs } from "@/type/Admin";
import { useEffect, useState } from "react";
import InputLabel from "./InputLabel";
import { useMutation } from "@tanstack/react-query";
import { productsService } from "@/api/services/Products";
import type { Product } from "@/type/Product";
import { XIcon } from "lucide-react";
import type { Category } from "@/type/Category";
import SelectCategory from "./SelectCategory";

export default function UpsertProductForm({
  categoriesData,
  productToUpdate,
  setProductToUpdate,
  onSubmit,
}: {
  categoriesData: Category[];
  productToUpdate?: Product;
  setProductToUpdate: (product: Product | undefined) => void;
  onSubmit?: () => void;
}) {
  const [inputs, setInputs] = useState<ProductInputs>({
    name: "",
    description: "",
    imageUrl: "",
    price: 0,
    stock: 0,
    categoryId: "",
  });

  function handleInputChange(e: React.ChangeEvent<HTMLInputElement>) {
    setInputs((prev) => ({
      ...prev,
      [e.target.name]: e.target.value,
    }));
  }

  function handleClearInputs() {
    setInputs({
      name: "",
      description: "",
      imageUrl: "",
      price: 0,
      stock: 0,
      categoryId: "",
    });
  }

  useEffect(() => {
    if (productToUpdate) {
      setInputs({
        name: productToUpdate.name,
        description: productToUpdate.description,
        imageUrl: productToUpdate.imageUrl,
        price: productToUpdate.price,
        stock: productToUpdate.stock,
        categoryId: "",
      });
    } else {
      handleClearInputs();
    }
  }, [productToUpdate]);

  const { mutate: addProductMutation } = useMutation({
    mutationFn: productsService.addProduct,
    onSuccess: () => {
      handleClearInputs();
      alert("Product added successfully!");
      onSubmit?.();
    },
    onError: () => {
      alert("Error adding product");
    },
  });

  const { mutate: updateProductMutation } = useMutation({
    mutationFn: productsService.updateProduct,
    onSuccess: () => {
      handleClearInputs();
      alert("Product updated successfully!");
      onSubmit?.();
    },
    onError: () => {
      alert("Error updating product");
    },
  });

  function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();

    if (!productToUpdate) {
      addProductMutation(inputs);
      return;
    }

    updateProductMutation({ ...inputs, productId: productToUpdate.productId });
  }

  return (
    <section className="flex flex-col gap-y-4">
      <div className="flex gap-x-3 items-center">
        <h1 className="text-2xl font-medium">
          {productToUpdate ? "Update" : "Add"} Product
        </h1>
        {productToUpdate && (
          <XIcon
            className="cursor-pointer size-5 -mb-1.5 text-white/85 hover:text-white/75 transition-colors duration-300"
            onClick={() => setProductToUpdate(undefined)}
          />
        )}
      </div>
      <form
        className="grid grid-cols-2 gap-y-6 gap-x-12"
        onSubmit={handleSubmit}
      >
        <InputLabel
          label="Name"
          type="text"
          name="name"
          value={inputs.name}
          onChange={handleInputChange}
        />
        <InputLabel
          label="Description"
          type="text"
          name="description"
          value={inputs.description}
          onChange={handleInputChange}
        />
        <InputLabel
          label="Price"
          type="number"
          name="price"
          value={inputs.price}
          onChange={handleInputChange}
        />
        <InputLabel
          label="Image"
          type="text"
          name="imageUrl"
          value={inputs.imageUrl}
          onChange={handleInputChange}
        />
        <InputLabel
          label="Stock"
          type="number"
          name="stock"
          value={inputs.stock}
          onChange={handleInputChange}
        />
        <SelectCategory
          label="Category"
          name="categoryId"
          value={inputs.categoryId}
          onChange={(value) => setInputs({ ...inputs, categoryId: value })}
          options={categoriesData}
        />
        <button className="col-span-2 bg-primary hover:bg-primary/85 transition-colors duration-300 py-3 px-6 rounded-md cursor-pointer">
          {productToUpdate ? "Update" : "Add"} Product
        </button>
      </form>
    </section>
  );
}
