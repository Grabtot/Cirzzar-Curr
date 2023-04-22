import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Home } from "./components/Home";
import ProductDetails from './components/ProductsManagement/ProductDetails/ProductDetails';
import ProductsManagement from './components/ProductsManagement/ProductsManagement';

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: "/menu/management/products",
    requireAuth: true,
    element: <ProductsManagement />
  },
  {
    path: "/menu/products/:id",
    element: <ProductDetails />
  },
  ...ApiAuthorzationRoutes
];

export default AppRoutes;
