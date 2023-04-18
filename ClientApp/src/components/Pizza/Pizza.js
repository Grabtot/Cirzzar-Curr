import React, { useState, useEffect } from 'react';
import PizzaList from './PizzaList/PizzaList';
import AddPizza from './AddPizza/AddPizza';
import { deleteProduct, getPizzaProducts, updateProduct } from '../api-products/ProductsService';

const Pizza = () => {
  const [pizzas, setPizzas] = useState([]);
  const [loading, setLoading] = useState(true);
  const fetchPizzas = async () => {
    const fetchedPizzas = await getPizzaProducts();
    setPizzas(fetchedPizzas);
    setLoading(false);
  };

  useEffect(() => {
    fetchPizzas();
  }, []);

  const onEdit = async (pizza) => {
    await updateProduct(pizza);
    await fetchPizzas();
  }

  const onDelete = async (id) => {
    await deleteProduct(id);
    await fetchPizzas();
  }

  return (
    <div>
      <h2>Pizzas</h2>
      <PizzaList pizzas={pizzas} loading={loading} onEdit={onEdit} onDelete={onDelete} />
      <AddPizza onPizzaAdded={fetchPizzas} />
    </div>
  );
};

export default Pizza;
