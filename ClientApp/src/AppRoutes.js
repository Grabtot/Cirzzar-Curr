import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Home } from "./components/Home";
import Pizza from './components/Pizza/Pizza';

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: "/menu/pizza",
    element: <Pizza />
  },
  ...ApiAuthorzationRoutes
];

export default AppRoutes;
