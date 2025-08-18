export default function InputLabel({
  label,
  name,
  value,
  onChange,
  type = "text",
  placeholder = "Type here...",
}: {
  label: string;
  name: string;
  value: string | number;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  type?: string;
  placeholder?: string;
}) {
  return (
    <div className="flex flex-col gap-y-1">
      <span className="text-white/75">{label}</span>
      <input
        type={type}
        name={name}
        value={value}
        onChange={(e) => onChange(e)}
        placeholder={placeholder}
        className="border border-zinc-700 p-3 w-full rounded-md"
      />
    </div>
  );
}
