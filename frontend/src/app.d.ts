import { SupabaseClient, Session, User} from "@supabase/supabase-js";

declare global {
	namespace App {
		interface Locals {
			supabase: SupaBase<Database>
			safeGetSession: () => Promise<{ session: Session | null; user: User | null }>
			session: Session | null
			user: User | null
		}
		interface PageData{
			sessionl: Session | null
		}
		// interface Error {}
		// interface Locals {}
		// interface PageData {}
		// interface PageState {}
		// interface Platform {}
	}
}

export {};
