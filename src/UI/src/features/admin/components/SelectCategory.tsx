import type { Category } from "@/type/Category";

export default function SelectCategory({
  label,
  name,
  value,
  onChange,
  options,
}: {
  label: string;
  name: string;
  value: string;
  onChange: (value: string) => void;
  options: Category[];
}) {
  return (
    <div className="flex flex-col gap-y-1">
      <span className="text-white/75">{label}</span>
      <select
        name={name}
        value={value ?? ""}
        onChange={(e) => onChange(e.target.value)}
        className="border border-zinc-700 p-3 w-full rounded-md bg-zinc-800 text-gray-200rounded-l-md focus:outline-none focus:ring-2 focus:ring-cyan-300"
      >
        {options?.map((option) => (
          <option key={option.categoryId} value={String(option.categoryId)}>
            {option.name}
          </option>
        ))}
      </select>
    </div>
  );
}
