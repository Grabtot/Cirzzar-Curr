import React, { useState } from 'react';
import IngredientsSelect from '../IngredientsSelect/IngredientsSelect';
import { addProduct } from '../../api-products/ProductsService';

const AddPizza = ({ onPizzaAdded }) => {
  const [pizza, setPizza] = useState(defaultPizza);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setPizza({ ...pizza, [name]: value });
  }



  const handleSubmit = (e) => {
    e.preventDefault();
    const pizzaWithType = { ...pizza, $type: 'CirzzarCurr.Models.Pizza, CirzzarCurr' };
    addProduct(pizzaWithType);
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
          Price:
          <input type="number" name="price" value={pizza.price} onChange={handleChange} />
        </label>
        <br />
        <label>
          Size:
          <input type="number" name="size" value={pizza.size} onChange={handleChange} />
        </label>
        <br />
        <IngredientsSelect onChange={handleChange} />
        <br />
        <button type="submit">Add Pizza</button>
      </form>
    </div>
  );
}

const defaultPizza = {
  name: "Pepperoni",
  price: 100,
  size: 200,
  image: null,
  type: 0,
  ingredients: [],
}

export default AddPizza;
