import React, { useEffect, useState } from 'react';
import { getPizzaIngredients } from '../../api-products/ProductsService';

const IngredientsSelect = ({ onChange }) => {
  const [ingredients, setIngredients] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getIngredients();
  }, []);


  const getIngredients = async () => {
    const ingredients = await getPizzaIngredients();
    setIngredients(ingredients);
    setLoading(false);
  }


  return (
    <div>
      <h3>Select ingredients</h3>
      {loading ? <p>Ingredients loading...</p>
        : ingredients.map(ing => <label>
          <input type='checkbox' value={ing.Name} onChange={onChange} />
          <span>{ing.Name}</span>
        </label>)}
    </div>
  );
}

export default IngredientsSelect;
