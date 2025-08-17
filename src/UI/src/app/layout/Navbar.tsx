export default function Navbar() {
    return (
        <header className="w-full h-20 flex items-center z-40 bg-gradient-to-b from-zinc-900/0">
            <div className="max-w-screen-2xl w-full mx-auto px-6 items-center flex justify-between">

                {/* Logo */}
                <h1>
                    <a href="/" className='logo'>
                        <img src="/images/logo.png"
                        width={60}
                        height={60}
                        alt="Efrain Feliz" />
                    </a>
                </h1>

                {/* Search */}
                <div className="flex items-center justify-center">
                    <select defaultValue="All" id="" className="p-2 bg-zinc-800 text-gray-200 border border-zinc-700 rounded-l-md focus:outline-none focus:ring-2 focus:ring-cyan-300">
                        <option value="All">All</option>
                        <option value="cpu">CPU</option>
                        <option value="gpu">GPU</option>
                        <option value="ram">RAM</option>
                        <option value="ssd">SSD</option>
                        <option value="hdd">HDD</option>
                    </select>
                    <input type="text" placeholder="Search..." className="border border-gray-300 px-4 py-2 w-md" />
                    <button className="p-2 bg-cyan-500 border border-cyan-500"><img src="/public/images/search .png" alt="Search" /></button>
                </div>
                <div>
                    <img src="/public/images/light_mode.png" alt="Profile" />
                </div>
            </div>
        </header>
    )
}