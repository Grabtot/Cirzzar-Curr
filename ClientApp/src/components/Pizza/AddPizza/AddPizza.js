import React, { useState } from 'react';
import IngredientsSelect from '../IngredientsSelect/IngredientsSelect';
import { addProduct } from '../../api-products/ProductsService';

const AddPizza = ({ onPizzaAdded }) => {
  const [pizza, setPizza] = useState(defaultPizza);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setPizza({ ...pizza, [name]: value });
  }

  const handleIngredientChange = (e) => {
    const { checked, value } = e.target;

    if (checked) {
      setPizza((prevPizza) => ({
        ...prevPizza,
        ingredients: [...prevPizza.ingredients, value],
      }));
    } else {
      setPizza((prevPizza) => ({
        ...prevPizza,
        ingredients: prevPizza.ingredients.filter((ing) => ing !== value),
      }));
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    addProduct(pizza);
    onPizzaAdded();
    console.log(pizza);
  }

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <label>
          Name:
          <input type="text" name="name" value={pizza.name} onChange={handleChange} />
        </label>
        <br />
        <label>
          Count:
          <input type="number" name="count" value={pizza.count} onChange={handleChange} />
        </label>
        <br />
        <label>
          Size:
          <input type="number" name="size" value={pizza.size} onChange={handleChange} />
        </label>
        <br />
        <label>
          Pizza Size:
          <select name="pizzaSize" value={pizza.pizzaSize} onChange={handleChange}>
            <option value="Small">Small</option>
            <option value="Medium">Medium</option>
            <option value="Large">Large</option>
            <option value="ExtraLarge">Extra Large</option>
          </select>
        </label>
        <br />
        <IngredientsSelect onChange={handleIngredientChange} />
        <br />
        <button type="submit">Add Pizza</button>
      </form>
    </div>
  );
}

const defaultPizza = {
  name: "Default Pizza",
  count: 1,
  size: 1,
  image: null,
  type: "Pizza",
  pizzaSize: "Medium",
  ingredients: [],
}

export default AddPizza;
