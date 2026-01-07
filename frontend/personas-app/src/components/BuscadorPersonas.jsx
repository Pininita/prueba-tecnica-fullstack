import React, { useState } from 'react';

const BuscadorPersonas = ({ onSearch }) => {
  const [termino, setTermino] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    onSearch(termino.trim());
  };

  const handleClear = () => {
    setTermino('');
    onSearch('');
  };

  return (
    <div className="bg-white rounded-lg shadow-md p-6 mb-6">
      <form onSubmit={handleSubmit} className="flex gap-2">
        <input
          type="text"
          placeholder="Buscar por nombre o apellido..."
          value={termino}
          onChange={(e) => setTermino(e.target.value)}
          className="flex-1 px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
        />
        <button
          type="submit"
          className="bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700 transition duration-200"
        >
          Buscar
        </button>
        {termino && (
          <button
            type="button"
            onClick={handleClear}
            className="bg-gray-500 text-white px-6 py-2 rounded-lg hover:bg-gray-600 transition duration-200"
          >
            Limpiar
          </button>
        )}
      </form>
    </div>
  );
};

export default BuscadorPersonas;