import type { Product } from "@/type/Product";
import ImageFallback from "@/assets/icons/Placeholder.png";
import { useMutation } from "@tanstack/react-query";
import { productsService } from "@/api/services/Products";

export default function ProductList({
  products,
  setProductToUpdate,
  onDelete,
}: {
  products: Product[];
  setProductToUpdate: (product: Product) => void;
  onDelete?: () => void;
}) {
  const { mutate: deleteProductMutation } = useMutation({
    mutationFn: productsService.deleteProduct,
    onSuccess: () => {
      alert("Product deleted successfully!");
      onDelete?.();
    },
    onError: () => {
      alert("Error deleting product");
    },
  });

  return (
    <section className="grid gap-4">
      {products.map((product) => (
        <div
          key={product.productId}
          className="flex items-center gap-4 border border-zinc-500 p-3 rounded-lg shadow-sm"
        >
          {/* Imagen del producto */}
          <img
            src={product.imageUrl}
            alt={product.name}
            className="w-16 h-16 object-cover rounded"
            onError={(e) => {
              const target = e.currentTarget as HTMLImageElement;
              target.onerror = null;
              target.src = ImageFallback;
            }}
          />

          {/* Nombre del producto */}
          <span className="flex-1 font-medium">{product.name}</span>

          {/* Botón Update */}
          <button
            className="px-3 py-1.5 bg-primary rounded hover:bg-primary/75 transition-colors duration-300 cursor-pointer"
            onClick={() => setProductToUpdate(product)}
          >
            Update
          </button>
          <button
            className="px-3 py-1.5 bg-red-400 rounded hover:bg-red-500 transition-colors duration-300 cursor-pointer"
            onClick={() => deleteProductMutation(product.productId)}
          >
            Delete
          </button>
        </div>
      ))}
    </section>
  );
}
