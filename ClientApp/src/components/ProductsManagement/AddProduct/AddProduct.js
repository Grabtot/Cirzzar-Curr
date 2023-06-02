import React, { useEffect, useState } from 'react';
import IngredientsSelect from '../IngredientsSelect/IngredientsSelect';
import { getProductTypes } from '../../api-products/ProductsService';

const AddProduct = ({ onAdd }) => {
  const [product, setProduct] = useState(defaultProduct);
  const [productTypes, setProductTypes] = useState([]);
  
  const handleChange = (e) => {
    const { name, value } = e.target;
    setProduct({ ...product, [name]: value });
  }

  const handleImageChange = async (e) => {
    const file = e.target.files[0];
    if (file) {
      const base64Image = await toBase64(file);
      setProduct({ ...product, image: base64Image });
    } else {
      setProduct({ ...product, image: null });
    }
  }

  const toBase64 = (file) => {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => resolve(reader.result);
      reader.onerror = (error) => reject(error);
    });
  }

  useEffect(() => {
    const fetchProductTypes = async () => {
      const productTypes = await getProductTypes();
      setProductTypes(productTypes);
      console.log("types", productTypes);
    }
    fetchProductTypes();
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    onAdd(product);
  }

  return (
    <div>
      <h3>Add New Product</h3>
      <form onSubmit={handleSubmit}>
        <label>
          Name:
          <input type="text" name="name" value={product.name} onChange={handleChange} />
        </label>
        <br />
        <label>
          Price:
          <input type="number" name="price" value={product.price} onChange={handleChange} />
        </label>
        <br />
        <label>
          Size:
          <input type="number" name="size" value={product.size} onChange={handleChange} />
        </label>
        <br />
        <label>
          Image:
          <input type="file" name="image" accept="image/*" onChange={handleImageChange} />
        </label>
        <br />
        <label>
          Type:
          <select value={product.type} name='type' onChange={handleChange}>
            {productTypes.map((type) => (
              <option key={type} value={type}>{type}</option>
            ))}
          </select>
        </label>
        <br />
        {product.type === "Pizza" ? < IngredientsSelect onChange={handleChange} /> : null}
        <br />
        <button type="submit">Add {product.type}</button>
      </form>
    </div>
  );
}

const defaultProduct = {
  name: "Product",
  price: 100,
  size: 200,
  image: null,
  type: "Dessert",
}

export default AddProduct;
