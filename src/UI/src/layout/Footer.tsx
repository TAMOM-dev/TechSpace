export default function Footer() {
  return (
    <footer className="w-full p-8 flex items-center justify-center bg-gradient-to-b from-zinc-900/0">
      <p className="text-sm opacity-75">
        &copy; {new Date().getFullYear()} TechSpace. All rights reserved.
      </p>
    </footer>
  );
}
